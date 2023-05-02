SET @Id_Commande = 13; -- Remplacez 1 par l'identifiant de la commande concernée
SET @Seuil_Alerte = 91; -- Remplacez 91 par le seuil d'alerte souhaité

-- Mise à jour du stock pour chaque produit commandé
UPDATE Stock s
JOIN Commande_Produit cp ON s.Id_Produit = cp.Id_Produit
JOIN Commande c ON s.Id_Magasin = c.Id_Magasin
SET s.Quantite = s.Quantite - cp.Quantite
WHERE cp.Id_Commande = @Id_Commande AND c.Id_Commande = @Id_Commande;

-- Visualisation mis à jour 
SELECT s.Id_Magasin, s.Id_Produit, p.Nom AS 'Nom du produit', s.Quantite AS 'Quantite en stock' -- 'Nom du produit'
FROM Stock s
JOIN Produit p ON s.Id_Produit = p.Id_Produit
ORDER BY s.Id_Magasin, s.Id_Produit;


-- Vérification du seuil d'alerte pour les produits du magasin concerné
SELECT s.Id_Magasin, s.Id_Produit, s.Quantite, p.Nom AS 'Nom du produit', s.Seuil_alerte -- 'Nom du produit'
FROM Stock s
JOIN Produit p ON s.Id_Produit = p.Id_Produit
JOIN Commande c ON s.Id_Magasin = c.Id_Magasin
WHERE c.Id_Commande = @Id_Commande AND s.Quantite <= @Seuil_Alerte;  -- Affihcer un message en c#

-- Consulter les stocks de tout les magasins en même temps 
SELECT s.Id_Magasin, m.Nom AS 'Nom du magasin', s.Id_Produit, p.Nom AS 'Nom du produit', s.Quantite
FROM Stock s
JOIN Magasin m ON s.Id_Magasin = m.Id_Magasin
JOIN Produit p ON s.Id_Produit = p.Id_Produit
ORDER BY s.Id_Magasin, s.Id_Produit;

-- Etat des commandes
DELIMITER //

CREATE PROCEDURE InsertCommande (
    IN p_Id_Client INT,
    IN p_Id_Magasin INT,
    IN p_Date_commande DATE,
    IN p_Adresse_livraison VARCHAR(255),
    IN p_message TEXT,
    IN p_Date_livraison_voulue DATE,
    IN p_Type_commande ENUM('Standard', 'Personalisee'),
    IN p_Prix_total DECIMAL(10,2),
    IN p_Reduction DECIMAL(4,2),
    IN p_Prix_maximum DECIMAL(10,2),
    IN p_Seuil_Alerte INT
)
BEGIN
    DECLARE p_Etat_commande ENUM('VINV', 'CC', 'CPAV', 'CAL', 'CL');

    IF p_Type_commande = 'Standard' THEN
        IF DATEDIFF(p_Date_livraison_voulue, p_Date_commande) >= 3 THEN
            SET p_Etat_commande = 'CC';
        ELSE
            SET p_Etat_commande = 'VINV';
        END IF;
    ELSEIF p_Type_commande = 'Personalisee' THEN
        SET p_Etat_commande = 'CPAV';
    END IF;

    INSERT INTO Commande (
        Id_Client, Id_Magasin, Date_commande, Adresse_livraison, message, Date_livraison_voulue, Etat_commande, Type_commande, Prix_total, Reduction, Prix_maximum
    )
    VALUES (
        p_Id_Client, p_Id_Magasin, p_Date_commande, p_Adresse_livraison, p_message, p_Date_livraison_voulue, p_Etat_commande, p_Type_commande, p_Prix_total, p_Reduction, p_Prix_maximum
    );

    SET @Id_Commande = LAST_INSERT_ID();

    -- Mise à jour du stock pour chaque produit commandé
    UPDATE Stock s
    JOIN Commande_Produit cp ON s.Id_Produit = cp.Id_Produit
    JOIN Commande c ON s.Id_Magasin = c.Id_Magasin
    SET s.Quantite = s.Quantite - cp.Quantite
    WHERE cp.Id_Commande = @Id_Commande AND c.Id_Commande = @Id_Commande;

    -- Mise à jour de l'état de la commande de CPAV vers CC seulement si s.Quantite >= @Seuil_Alerte
    UPDATE Commande
    SET Etat_commande = 'CC'
    WHERE Id_Commande = @Id_Commande 
    AND Etat_commande = 'CPAV'
    AND NOT EXISTS (
        SELECT 1
        FROM Stock s
        JOIN Commande_Produit cp ON s.Id_Produit = cp.Id_Produit
        JOIN Commande c ON s.Id_Magasin = c.Id_Magasin
        WHERE cp.Id_Commande = @Id_Commande AND c.Id_Commande = @Id_Commande AND s.Quantite < p_Seuil_Alerte
    );
END;
//

DELIMITER ;
-- Tentative de faire fonctionner la procédure 
SET @p_Id_Client = 1;
SET @p_Id_Magasin = 1;
SET @p_Date_commande = '2023-05-01';
SET @p_Adresse_livraison = '123 Rue des Exemples';
SET @p_message = 'Livrer au pas de la porte, merci.';
SET @p_Date_livraison_voulue = '2023-05-05';
SET @p_Type_commande = 'Standard';
SET @p_Prix_total = 100.00;
SET @p_Reduction = 5.00;
SET @p_Prix_maximum = 200.00;
SET @p_Seuil_Alerte = 10;

-- Procédure commande standard
use fleurs
DELIMITER //

CREATE PROCEDURE CreateStandardOrder(
    IN p_Id_Client INT, 
    IN p_Id_Magasin INT, 
    IN p_Date_commande DATE, 
    IN p_Adresse_livraison VARCHAR(255), 
    IN p_Message TEXT, 
    IN p_Date_livraison_voulue DATE, 
    IN p_Etat_commande ENUM('VINV','CC','CPAV','CAL','CL'), 
    IN p_Type_commande ENUM('Standard', 'Personalisee')
)
BEGIN
  DECLARE v_BouquetPrice DECIMAL(10,2);
  DECLARE v_ClientFidelity ENUM('Or', 'Bronze', 'Aucun');
  DECLARE v_Reduction DECIMAL(4,2);
  
  -- Récupérer le prix du bouquet
  SELECT Prix INTO v_BouquetPrice
  FROM Bouquet
  WHERE Nom = p_Message;

  -- Récupérer la fidélité du client
  SELECT fidelite INTO v_ClientFidelity
  FROM Client
  WHERE Id_client = p_Id_Client;
  
  -- Déterminer la réduction en fonction de la fidélité du client
  IF v_ClientFidelity = 'Or' THEN
    SET v_Reduction = 0.15;
  ELSEIF v_ClientFidelity = 'Bronze' THEN
    SET v_Reduction = 0.05;
  ELSE
    SET v_Reduction = 0;
  END IF;
  
  -- Appliquer la réduction (si elle existe) au prix du bouquet
  SET v_BouquetPrice = v_BouquetPrice * (1 - v_Reduction);

  -- Insérer la nouvelle commande dans la table Commande avec le message contenant le nom du bouquet et son prix
  INSERT INTO Commande (Id_Client, Id_Magasin, Date_commande, Adresse_livraison, message, Date_livraison_voulue, Etat_commande, Type_commande, Prix_total, Reduction, Prix_maximum)
  VALUES (p_Id_Client, p_Id_Magasin, p_Date_commande, p_Adresse_livraison, p_Message, p_Date_livraison_voulue, p_Etat_commande, p_Type_commande, v_BouquetPrice, v_Reduction, NULL);

  -- Récupérer l'Id_Commande généré automatiquement lors de l'insertion
  SET @last_id_commande = LAST_INSERT_ID();

  -- Récupérer l'Id_Bouquet correspondant au nom du bouquet renseigné dans le message
  SELECT Id_Bouquet INTO @bouquet_id
  FROM Bouquet
  WHERE Nom = p_Message;

  -- Insérer une nouvelle entrée dans la table Commande_Bouquet avec l'Id_Commande et l'Id_Bouquet récupérés
  INSERT INTO Commande_Bouquet (Id_Commande, Id_Bouquet, Quantite)
  VALUES (@last_id_commande, @bouquet_id, 1);
END//

DELIMITER ;


 


CALL CreateStandardOrder(1, 1, '2023-05-02', '15 rue des Lilas, Paris', 'L\'Amoureux', '2023-05-04', 'VINV', 'Standard'); -- à la place de l'amoureux tu peux mettre celui renseigné par la cliente 


SELECT *
FROM Commande
WHERE message LIKE '%L\'Amoureux%';