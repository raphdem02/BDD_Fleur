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
    /// Logique d'interaction pour ClientConnexion.xaml
    /// </summary>
    public partial class ClientConnexion : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        public ClientConnexion()
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
        /// Button to connect to a client space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            
            if(TextBoxEmailC.Text != "" && TextBoxPwdC.Text != "")
            {
                string EmailC = TextBoxEmailC.Text;
                string PwdC = TextBoxPwdC.Text;
                string Lastname = "";
                string Firstname = "";
                string phone = "";
                string bluecardnumber = "";
                string fidelity = "";
                OpenConnection();
                string query = "SELECT * FROM Client WHERE e_mail = @email AND mdp = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", EmailC);
                command.Parameters.AddWithValue("@password", PwdC);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Récupérez les données de chaque colonne dans la table Client
                        int id = reader.GetInt32("Id_client");
                        string nom = reader.GetString("Nom");
                        string prenom = reader.GetString("Prenom");
                        string tel = reader.GetString("N_tel");
                        string e_mail = reader.GetString("e_mail");
                        string mdp = reader.GetString("mdp");
                        string bluecard = reader.GetString("carte_credit");
                        string fidel = reader.GetString("fidelite");
                        // Faites quelque chose avec les données récupérées
                        Lastname = nom;
                        Firstname = prenom;
                        phone = tel;
                        bluecardnumber = bluecard;
                        fidelity = fidel;

                    }
                }
                CloseConnection();
                ClientDashboard ClientDashboardPage = new ClientDashboard(EmailC, PwdC, Firstname, Lastname, phone, bluecardnumber,fidelity) ;
                ClientDashboardPage.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Button to create a new client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            NewClient NewClientPage = new NewClient();
            NewClientPage.Show();
            this.Close();
        }

        /// <summary>
        /// Button to come back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
