drop database if exists Fleurs;

create database Fleurs;

use Fleurs;

create table Client(
	Id_client int primary key,
    Nom varchar(50),
    Prenom varchar(50),
    N_tel varchar(15),
    e_mail varchar(100) unique,
    mdp varchar(100),
    carte_bancaire varchar(20),
    fidelite enum('Or', 'Bronze', 'Aucun') default 'Aucun'
);

create table Produit(
	Id_produit int primary key,
    Nom varchar(75),
    type enum('Fleur', 'accesoire'),
    prix decimal(10, 2),
    Dispo varchar(200)
);

create table Commande(
	Id_Commande int primary key,
    Id_Client int,
    Date_commande date,
    Adresse_livraison varchar(255),
    message text,
    Date_livraison_voulue date,
    Etat_commande enum('VINV','CC','CPAV','CAL','CL'),
    Type_commande enum('Standard', 'Personalisee'),
    Prix_total decimal(10,2),
    foreign key (Id_Client) references Client(Id_Client)
);

create table Commande_Produit(
	Id_Commande int,
    Id_Produit int,
    Quantite int, 
    primary key (Id_Commande, Id_Produit),
    foreign key (Id_Commande) references Commande(Id_Commande),
    foreign key (Id_Produit) references Produit(Id_Produit)
);


create table Bouquet(
	Id_Bouquet int primary key,
    Nom varchar(100),
    Description text,
    Prix decimal(10, 2),
    Categorie varchar(100)
);

create table Bouquet_Produit(
	Id_Bouquet int,
    Id_Produit int,
    primary key (Id_Bouquet, Id_Produit),
    foreign key (Id_Bouquet) references Bouquet(Id_Bouquet),
    foreign key (Id_Produit) references Produit(Id_Produit)
);

create table Magasin(
	Id_Magasin int primary key,
    Nom varchar(100),
    Adresse varchar(255)
);

create table Stock(
	Id_Magasin int,
    Id_Produit int, 
    Quantite int, 
    Seuil_alerte int,
    primary key (Id_Magasin, Id_Produit),
    foreign key (Id_Magasin) references Magasin(Id_Magasin),
    foreign key (Id_Produit) references Produit(Id_Produit)
);
    


    