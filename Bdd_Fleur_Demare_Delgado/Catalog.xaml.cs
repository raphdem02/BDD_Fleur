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

namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Logique d'interaction pour Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");

        private string email;
        private string pwd;
        public Catalog(string email,string pwd)
        {
            InitializeComponent();
            this.email = email;
            this.pwd = pwd;
        }

        /// <summary>
        /// Clear all textbox
        /// </summary>
        private void BoxClear()
        {
            //TODO
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
        /// Button to go back to client dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            ClientDashboard ClientDashboardPage = new ClientDashboard(email, pwd);
            ClientDashboardPage.Show();
            this.Close();
        }

        /// <summary>
        /// Button to go to new order page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ButtonNewOrderC_Click(object sender, RoutedEventArgs e)
        {
            ClientNewOrder ClientNewOrderPage = new ClientNewOrder(email, pwd);
            ClientNewOrderPage.Show();
            this.Close();
        }
    }
}
