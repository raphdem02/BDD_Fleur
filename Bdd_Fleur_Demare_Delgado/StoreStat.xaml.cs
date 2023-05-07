using System;
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
using System.IO;


namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Logique d'interaction pour StoreStat.xaml
    /// </summary>
    public partial class StoreStat : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        private string idStore;
        public StoreStat()
        {
            InitializeComponent();
        }

        public StoreStat(string id)
        {
            InitializeComponent();
            this.idStore = id;
            TextBoxPrice.Text = HavePrice();
            TextBoxBestBouqet.Text = BestBouquet();
            TextBoxBestStore.Text = BestStoreCA();
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
        /// Function to Have the average price of a bouquet
        /// </summary>
        /// <returns></returns>
        public string HavePrice()
        {
            
            string query = "SELECT AVG(Prix_total) as Prix_Moyen FROM Commande WHERE Type_commande = 'Standard';";
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            string PriceBouquetMoyenne = command.ExecuteScalar().ToString();
            CloseConnection();
            return PriceBouquetMoyenne;
        }

        /// <summary>
        /// Function to have the best bouquet and the number of order
        /// </summary>
        /// <returns></returns>
        public string BestBouquet()
        {
            string query = "SELECT b.Id_Bouquet, b.Nom, COUNT(*) as Nombre_commandes " +
                           "FROM Commande_Bouquet cb " +
                           "JOIN Commande c ON cb.Id_Commande = c.Id_Commande " +
                           "JOIN Bouquet b ON cb.Id_Bouquet = b.Id_Bouquet " +
                           "WHERE c.Type_commande = 'Standard' " +
                           "GROUP BY b.Id_Bouquet, b.Nom " +
                           "ORDER BY Nombre_commandes DESC " +
                           "LIMIT 1;";
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int idBouquet = reader.GetInt32("Id_Bouquet");
            string nomBouquet = reader.GetString("Nom");
            string nombreCommandes = reader.GetInt32("Nombre_commandes").ToString();
            CloseConnection();
            string final = nomBouquet + " avec " + nombreCommandes + " commandes";
            return final;
        }

        /// <summary>
        /// Function to have the best store
        /// </summary>
        /// <returns></returns>
        public string BestStoreCA()
        {
            string query = "SELECT Id_Magasin, SUM(Prix_total) as Chiffre_affaires " +
                           "FROM Commande " +
                           "GROUP BY Id_Magasin " +
                           "ORDER BY Chiffre_affaires DESC " +
                           "LIMIT 1;";
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string idMagasin = reader.GetInt32("Id_Magasin").ToString();
            string chiffreAffaires = reader.GetDouble("Chiffre_affaires").ToString();
            CloseConnection();
            string final = "Magasin " + idMagasin + " avec un CA de " + chiffreAffaires + " €";
            return final;
        }
        /// <summary>
        /// Button to have the  best clients of the month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonBestClientMonth_Click(object sender, RoutedEventArgs e)
        {
            OpenConnection();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT Id_client, SUM(Prix_total) as Total_mensuel " +
                           "FROM Commande " +
                           "WHERE MONTH(Date_commande) = MONTH(CURRENT_DATE()) AND YEAR(Date_commande) = YEAR(CURRENT_DATE()) " +
                           "GROUP BY Id_client " +
                           "ORDER BY Total_mensuel DESC;";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }

        /// <summary>
        /// Button to have the  best clients of the year 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonBestClientYear_Click(object sender, RoutedEventArgs e)
        {
            OpenConnection();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT Id_client, SUM(Prix_total) as Total_annuel " +
                           "FROM Commande " +
                           "WHERE YEAR(Date_commande) = YEAR(CURRENT_DATE()) " +
                           "GROUP BY Id_client " +
                           "ORDER BY Total_annuel DESC;";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }

        /// <summary>
        /// Button to have the best sales of items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonBestItem_Click(object sender, RoutedEventArgs e)
        {
            OpenConnection();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM (" +
                           "  SELECT 'Bouquet' as Type, b.Id_Bouquet as Id, b.Nom, SUM(cb.Quantite) as Quantite_vendue " +
                           "  FROM Commande_Bouquet cb " +
                           "  JOIN Bouquet b ON cb.Id_Bouquet = b.Id_Bouquet " +
                           "  GROUP BY b.Id_Bouquet, b.Nom " +
                           "  ORDER BY Quantite_vendue DESC " +
                           "  LIMIT 5 " +
                           ") AS Bouquets " +
                           "UNION " +
                           "SELECT * FROM (" +
                           "  SELECT 'Produit' as Type, p.Id_Produit as Id, p.Nom, SUM(cp.Quantite) as Quantite_vendue " +
                           "  FROM Commande_Produit cp " +
                           "  JOIN Produit p ON cp.Id_Produit = p.Id_Produit " +
                           "  GROUP BY p.Id_Produit, p.Nom " +
                           "  ORDER BY Quantite_vendue DESC " +
                           "  LIMIT 5 " +
                           ") AS Produits " +
                           "ORDER BY Quantite_vendue DESC;";
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }
        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        } 
    }
}