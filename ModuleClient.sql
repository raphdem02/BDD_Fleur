-- Requete connexion client
DELIMITER //
CREATE PROCEDURE VerifierEmail(
    IN p_e_mail VARCHAR(100),
    OUT p_message VARCHAR(255)
)
BEGIN
    DECLARE v_exists INT;

    SELECT COUNT(*) INTO v_exists
    FROM Client
    WHERE e_mail = p_e_mail;

    IF v_exists = 1 THEN
        SET p_message = 'Adresse e-mail déjà prise, veuillez en renseigner une autre';
    ELSE
        SET p_message = 'Adresse e-mail disponible';
    END IF;
END //
DELIMITER ;

SET @message = NULL;
CALL VerifierEmail('pierre.dupont@email.com', @message);
SELECT @message AS Message;

-- Requete inscription client 
#INSERT INTO Client (Id_client, Nom, Prenom, N_tel, e_mail, mdp, carte_credit, fidelite, date_creation) VALUES (int, varchar, varchar, varchar, varchar, varchar, varchar, 'Aucun', date)

-- Requete fidélité 
-- Remplacez CLIENT_ID par l'ID du client 
SET @client_id = 1;
SELECT 
    Id_Client,
    COUNT(*) AS total_commandes,
    COUNT(*) / GREATEST(TIMESTAMPDIFF(MONTH, MIN(Date_commande), NOW()), 1) AS commandes_par_mois
FROM Commande WHERE Id_Client = @client_id GROUP BY Id_Client;
-- Mettre à jour le statut de fidélité 
UPDATE Client
SET fidelite = (
    SELECT CASE
        WHEN commandes_par_mois > 5 THEN 'Or'
        WHEN commandes_par_mois >= 1 THEN 'Bronze'
        ELSE 'Aucun'
    END
    FROM (
        SELECT 
            COUNT(*) / GREATEST(TIMESTAMPDIFF(MONTH, MIN(Date_commande), NOW()), 1) AS commandes_par_mois
        FROM Commande WHERE Id_Client = @client_id GROUP BY Id_Client
    ) AS subquery
)
WHERE Id_client = @client_id;
SET @client_id = 1;
SELECT Id_client, Nom, Prenom, fidelite FROM Client WHERE Id_client = @client_id;

SELECT 
    c.Id_Client,
    com.Id_Commande,
    com.Date_commande,
    com.Prix_total,
    p.Id_Produit,
    p.Nom AS Nom_Produit,
    cp.Quantite AS Quantite_Produit,
    b.Id_Bouquet,
    b.Nom AS Nom_Bouquet,
    cb.Quantite AS Quantite_Bouquet
FROM Commande com
JOIN Client c ON com.Id_Client = c.Id_client
LEFT JOIN Commande_Produit cp ON com.Id_Commande = cp.Id_Commande
LEFT JOIN Produit p ON cp.Id_Produit = p.Id_Produit
LEFT JOIN Commande_Bouquet cb ON com.Id_Commande = cb.Id_Commande
LEFT JOIN Bouquet b ON cb.Id_Bouquet = b.Id_Bouquet
WHERE c.Id_client = 1 -- @clien_id
ORDER BY com.Date_commande DESC, com.Id_Commande, p.Id_Produit, b.Id_Bouquet;
