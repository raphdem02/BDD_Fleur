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
        private void AfficherCommande()
        {
            OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from stock where id_Magasin = @id_Store";
            command.Parameters.AddWithValue("@id_store", idStore);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }
        private void BouttonAjouter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BouttonRetirer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            AfficherCommande();
        }

        private void BouttonInfoCommande_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BouttonInfoPiece_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BouttonInfoVelo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        }
    }
}
