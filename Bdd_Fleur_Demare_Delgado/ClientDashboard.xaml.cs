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
    /// Logique d'interaction pour ClientDashboard.xaml
    /// </summary>
    public partial class ClientDashboard : Window
    {

        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        /// <summary>
        /// Var to save what client's page we are visiting
        /// </summary>
        private string email;
        private string pwd;
        private string FirstName;
        private string LastName;
        private string phone;
        private string bluecardNumber;
        private string fidelity;

        public ClientDashboard()
        {
            InitializeComponent();
        }

        public ClientDashboard(string email, string pwd,string FirstName,string LastName,string phone,string bluecardNumber,string fidelity)
        {
            InitializeComponent();
            this.email = email;
            this.pwd = pwd;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.phone = phone;
            this.bluecardNumber = bluecardNumber;
            this.fidelity = fidelity;

            
            TextBoxEmailC.Text = email;
            TextBoxPwdC.Text = pwd;
            TextBoxFirstNameC.Text = FirstName;
            TextBoxLastNameC.Text = LastName;
            TextBoxPhoneC.Text = phone;
            TextBoxBluecardNumberC.Text = bluecardNumber;
            TextBoxFidelity.Text = fidelity;

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
        /// Button to return to main menu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Button to go to new order page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewOrderC_Click(object sender, RoutedEventArgs e)
        {
            ClientNewOrder ClientNewOrderPage = new ClientNewOrder(email, pwd, FirstName, LastName,phone,bluecardNumber,fidelity);
            ClientNewOrderPage.Show();
            this.Close();
        }

        /// <summary>
        /// Button to go the catalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCatalog_Click(object sender, RoutedEventArgs e)
        {
            Catalog CatalogPage = new Catalog(email, pwd, FirstName, LastName, phone, bluecardNumber, fidelity);
            CatalogPage.Show();
            this.Close();
        }
    }
}
