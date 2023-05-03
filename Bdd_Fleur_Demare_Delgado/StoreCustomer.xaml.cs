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

namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Logique d'interaction pour StoreCustomer.xaml
    /// </summary>
    public partial class StoreCustomer : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        private string idStore;
        public StoreCustomer()
        {
            InitializeComponent();
        }

        public StoreCustomer(string id)
        {
            InitializeComponent();
            this.idStore = id;
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
        /// Permet d'afficher la liste des commande d'un client
        /// </summary>
        private void AfficherCommandeClient(string idClient)
        {
            OpenConnection();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT 
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
                        WHERE c.Id_client = @client_id
                        ORDER BY com.Date_commande DESC, com.Id_Commande, p.Id_Produit, b.Id_Bouquet;";
            command.Parameters.AddWithValue("@client_id", idClient);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            //dataGrid.ItemsSource = command.ExecuteReader();
            

        
        CloseConnection();
        }
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxMailCustomer.Text;

            OpenConnection();
            // Création de la commande SQL
            string sql = "SELECT Id_client FROM Client WHERE e_mail = @email;";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);

            // Exécution de la commande SQL et récupération de l'ID du client
            string clientId = command.ExecuteScalar().ToString();

            CloseConnection();
            AfficherCommandeClient(clientId);
            
        }

        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        }
    }
}
