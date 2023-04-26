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
    /// Logique d'interaction pour NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        public NewClient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Clear all textbox
        /// </summary>
        private void BoxClear()
        {
            TextBoxEmailC.Text = "";
            TextBoxPwdC.Text = "";
            TextBoxLastNameC.Text = "";
            TextBoxFirstNameC.Text = "";
            TextBoxStreetC.Text = "";
            TextBoxCityC.Text = "";
            TextBoxCountryC.Text = "";
            TextBoxPhoneC.Text = "";
            TextBoxBluecardNumberC.Text = "";
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
        /// Button to create new client account 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreateAccountC_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxEmailC.Text != "" && TextBoxPwdC.Text != "" && TextBoxFirstNameC.Text != "" && TextBoxLastNameC.Text != "" && TextBoxStreetC.Text != "" && TextBoxCityC.Text != "" && TextBoxCountryC.Text !="" && TextBoxPhoneC.Text != "" && TextBoxBluecardNumberC.Text != "")
            {
                string EmailC = TextBoxEmailC.Text;
                string PwdC = TextBoxPwdC.Text;
                string LastNameC = TextBoxLastNameC.Text;
                string FirstNameC = TextBoxFirstNameC.Text;
                string StreetC = TextBoxStreetC.Text;
                string CityC = TextBoxCityC.Text;
                string CountryC = TextBoxCountryC.Text;
                string PhoneC = TextBoxPhoneC.Text;
                string BluecardNumberC = TextBoxBluecardNumberC.Text;

                //TODO query to add client to DB
                ClientDashboard ClientDashboardPage = new ClientDashboard(EmailC,PwdC);
                ClientDashboardPage.Show();
                this.Close();
            }
        }
    }
}
