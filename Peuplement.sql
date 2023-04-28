-- Insérer un client
INSERT INTO Client (Id_client, Nom, Prenom, N_tel, e_mail, mdp, carte_credit, fidelite, date_creation) VALUES (1, 'Martin', 'Alice', '0623456789', 'alice.martin@gmail.com', 'password123', '1234567812345678', 'Or', '2021-11-01');

-- Peupler la table Produit
INSERT INTO Produit (Id_Produit, Nom, type, prix, Disponibilite)
VALUES (1, 'Rose', 'Fleur', 2.00, 'à l\'année'),
       (2, 'Tulipe', 'Fleur', 1.50, 'à l\'année'),
       (3, 'Pensée', 'Fleur', 4.00, 'à l\'année'),
       (4, 'Gerbera', 'Fleur', 5.00, 'à l\'année'),
       (5, 'Ginger', 'Fleur', 4.00, 'à l\'année'),
       (6, 'Glaïeul', 'Fleur', 1.00, 'mai à novembre'),
       (7, 'Marguerite', 'Fleur', 2.25, 'à l\'année'),
       (8, 'Rose rouge', 'Fleur', 2.50, 'à l\'année'),
       (9, 'Rose blanche', 'Fleur', 2.50, 'à l\'année'),
       (10, 'Orchidée', 'FLeur', '25.00', 'à l\'année'),
       (11,'Oiseaux du paradis','Fleur', '10.00', 'à l\'année'),
       (12,'Alstromeria','Fleur', '7.50', 'à l\'année'),
       (13,'Verdure','Fleur', '1.00', 'à l\'année'),
       (14,'Lys','Fleur', '8.00', 'à l\'année'),
       (15,'Genet','Fleur', '2.00', 'à l\'année'),
       (16, 'Vase', 'accesoire', 15.00, 'à l\'année'),
       (17, 'Ruban', 'accesoire', 1.00, 'à l\'année'),
       (18, 'Boite', 'accesoire', 5.00, 'à l\'année'),
       (19, 'Embalage', 'accesoire', 2.00, 'à l\'année'),
       (20, 'Gysophiles', 'Fleur', 4.00, 'à l\'année'),
       (21, 'Anémone', 'Fleur', 1.50, 'à l\'année'),
       (22, 'Cosmon', 'Fleur', 3.00, 'à l\'année'),
       (23, 'Dille', 'Fleur', 2.500, 'à l\'année');
       
       
-- Peupler la table Bouquet
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (1, 'Gros Merci', 'Arrangement floral avec marguerites et verdure', 45.00, 'Toute occasion');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (2, 'L\'amoureux', 'Arrangement floral avec roses blanches et roses rouges', 65.00, 'St-Valentin');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (3, 'L\'Exotique', 'Arrangement floral avec ginger, oiseaux du paradis, roses et genet', 40.00, 'Toute occasion');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (4, 'Maman', 'Arrangement floral avec gerbera, roses blanches, lys et alstroméria', 80.00, 'Fête des mères');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (5, 'Vive la mariée', 'Arrangement floral avec lys et orchidées', 120.00, 'Mariage');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (6, 'Belle-maman', 'Arrangement floral orchydée verdure, vase et Ruban', 90.00, 'Toute occasion');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (7, 'Mia', 'Arrangement floral tulipes et Gysophiles', 27.00, 'Retour du Printemps');
INSERT INTO Bouquet (Id_Bouquet, Nom, Description, Prix, Categorie) VALUES (8, 'Charlie', 'Arrangement floral anémone, cosmos et Dille', 39.00, 'Naissance');

-- Peupler la table Bouquet_Produit
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (1, 7);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (1, 13); -- verudre
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit)VALUES (2, 9); -- L'amoureux (Id_Bouquet = 2) contient des roses blanches (Id_Produit = 9)
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit)VALUES (2, 8); -- L'amoureux (Id_Bouquet = 2) contient des roses rouges (Id_Produit = 8)
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (3,5); -- contient ginger
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (3,11); -- contient oiseaux paradis
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (3,1); -- rose
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (3,15); -- genet
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (4,5); -- ginger
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (4,9); -- rb
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (4,14); -- lys
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (4,12); -- alstrometria
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (5,14);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (5,10); -- orchidée
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (6,10);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (6,13); 
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (6,16);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (7,2); -- tulipes
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (7,20);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (8,21);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (8,22);
INSERT INTO Bouquet_Produit (Id_Bouquet, Id_Produit) VALUES (8,23);





-- Peupler la table Magasin
INSERT INTO Magasin (Id_Magasin, Nom, Adresse) VALUES (1, 'Fleurs du Paradis', '15 rue des Lilas, Paris');
INSERT INTO Magasin (Id_Magasin, Nom, Adresse) VALUES (2, 'Fleur & Co', '8 Avenue Hoche, Paris');
INSERT INTO Magasin (Id_Magasin, Nom, Adresse) VALUES (3, 'LéoCréa', '2 Avenue Léonard');
-- Peupler la table Stock

-- Peupler la table Inventaire pour chaque magasin
INSERT INTO Stock (Id_Magasin, Id_Produit, Quantite) 
VALUES 
(1, 1, 100),
(1, 2, 100),
(1, 3, 100),
(1, 4, 100),
(1, 5, 100),
(1, 6, 100),
(1, 7, 100),
(1, 8, 100),
(1, 9, 100),
(1, 10, 100),
(1, 11, 100),
(1, 12, 100),
(1, 13, 100),
(1, 14, 100),
(1, 15, 100),
(1, 16, 100),
(1, 17, 100),
(1, 18, 100),
(1, 19, 100),
(1, 20, 100),
(1, 21, 100),
(1, 22, 100),
(1, 23, 100);

INSERT INTO Stock (Id_Magasin, Id_Produit, Quantite) 
VALUES 
(2, 1, 100),
(2, 2, 100),
(2, 3, 100),
(2, 4, 100),
(2, 5, 100),
(2, 6, 100),
(2, 7, 100),
(2, 8, 100),
(2, 9, 100),
(2, 10, 100),
(2, 11, 100),
(2, 12, 100),
(2, 13, 100),
(2, 14, 100),
(2, 15, 100),
(2, 16, 100),
(2, 17, 100),
(2, 18, 100),
(2, 19, 100),
(2, 20, 100),
(2, 21, 100),
(2, 22, 100),
(2, 23, 100);

INSERT INTO Stock (Id_Magasin, Id_Produit, Quantite) 
VALUES 
(3, 1, 100),
(3, 2, 100),
(3, 3, 100),
(3, 4, 100),
(3, 5, 100),
(3, 6, 100),
(3, 7, 100),
(3, 8, 100),
(3, 9, 100),
(3, 10, 100),
(3, 11, 100),
(3, 12, 100),
(3, 13, 100),
(3, 14, 100),
(3, 15, 100),
(3, 16, 100),
(3, 17, 100),
(3, 18, 100), 
(3, 19, 100),
(3, 20, 100),
(3, 21, 100),
(3, 22, 100),
(3, 23, 100);


-- Peupler la table Commande
INSERT INTO Commande (Id_Commande, Id_Client, Id_Magasin, Date_commande, Adresse_livraison, message, Date_livraison_voulue, Etat_commande, Type_commande, Prix_total, Reduction, Prix_maximum)
VALUES (1, 1, 1, '2023-04-28', '15 rue des Lilas, Paris', 'Félicitations !', '2023-04-30', 'VINV', 'Standard', 25.00, 0.00, NULL);

-- Peupler la table Commande_Produit
INSERT INTO Commande_Produit (Id_Commande, Id_Produit, Quantite)
VALUES (1, 1, 10);

-- Peupler la table Commande_Bouquet
INSERT INTO Commande_Bouquet (Id_Commande, Id_Bouquet, Quantite)
VALUES (1, 1, 1);

