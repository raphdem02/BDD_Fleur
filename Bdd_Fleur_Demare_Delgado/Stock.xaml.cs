﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;

namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>   
    /// Logique d'interaction pour Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        private string idStore;
        public Stock()
        {
            InitializeComponent();
        }

        public Stock(string id)
        {
            InitializeComponent();
            this.idStore = id;
            AfficherStock();
        }


        /// <summary>
        /// Clear all textbox
        /// </summary>
        private void BoxClear()
        {

        }
        /// <summary>
        /// Open connection to database
        /// </summary>
        public void OpenConnection()
        {
            connection.Open();
        }
        /// <summary>
        /// Close connection to database
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Execute la requête demandée si possible ou retourne l'erreur
        /// </summary>
        /// <param name="query"> Requête à executer </param>
        public void ExecuteQuery(String query)
        {
            try
            {
                OpenConnection();

                MySqlCommand command = new MySqlCommand(query, connection);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Opération exécutée");
                }
                else
                {
                    MessageBox.Show("Opération non exécutée");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message);
                BoxClear();
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Permet d'afficher la liste des stock 
        /// </summary>
        private void AfficherStock()
        {
            OpenConnection();
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT s.Id_Magasin, m.Nom AS 'Nom du magasin', s.Id_Produit, p.Nom AS 'Nom du produit', s.Quantite " +
                             "FROM Stock s " +
                             "JOIN Magasin m ON s.Id_Magasin = m.Id_Magasin " +
                             "JOIN Produit p ON s.Id_Produit = p.Id_Produit " +
                             "WHERE s.Id_Magasin = @idMagasin " +
                             "ORDER BY s.Id_Magasin, s.Id_Produit;";
            command.Parameters.AddWithValue("@idMagasin", idStore);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }
        /// <summary>
        /// Allow to set new quantity of product when out of stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            string nouvelleQuantite = TextBoxQuantity.Text;
            string idProduit = TextBoxProductId.Text;
            OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Stock SET Quantite = @nouvelleQuantite WHERE Id_Magasin = @idMagasin AND Id_Produit = @idProduit;";
            command.Parameters.AddWithValue("@nouvelleQuantite", nouvelleQuantite);
            command.Parameters.AddWithValue("@idMagasin", idStore);
            command.Parameters.AddWithValue("@idProduit", idProduit);
            command.ExecuteNonQuery();
            CloseConnection();
            AfficherStock();

        }

        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        }
    }
}
