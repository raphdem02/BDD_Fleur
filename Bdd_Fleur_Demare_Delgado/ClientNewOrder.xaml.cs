using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Logique d'interaction pour ClientNewOrder.xaml
    /// </summary>
    public partial class ClientNewOrder : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");

        private string email;
        private string pwd;
        private string FirstName;
        private string LastName;
        private string phone;
        private string bluecardNumber;
        private string fidelity;
        public ClientNewOrder(string email, string pwd, string FirstName, string LastName, string phone, string bluecardNumber, string fidelity)
        {
            InitializeComponent();
            this.email = email;
            this.pwd = pwd;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.phone = phone;
            this.bluecardNumber = bluecardNumber;
            this.fidelity = fidelity;
            BoxClear();
        }

        /// <summary>
        /// Clear all textbox
        /// </summary>
        private void BoxClear()
        {
            TextBoxCustomizeC.Text = "";
            TextBoxStore.Text = "";
            TextBoxDeliveryAdressC.Text = "";
            TextBoxDeliveryDateC.Text = "2023-05-02";
            TextBoxDescript.Text = "";
            TextBoxReduction.Text = fidelity;
            TextBoxPrice.Text = "";
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

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            ClientDashboard ClientDashboardPage = new ClientDashboard(email, pwd, FirstName, LastName, phone, bluecardNumber, fidelity);
            ClientDashboardPage.Show();
            this.Close();
        }

        private void ButtonValidateOrderC_Click(object sender, RoutedEventArgs e)
        {
            string customize = TextBoxCustomizeC.Text;
            string store = TextBoxStore.Text;
            string DeliveryAdress = TextBoxDeliveryAdressC.Text;
            string DeliveryDate = TextBoxDeliveryDateC.Text;
            string description = TextBoxDescript.Text;
            string reduction = TextBoxReduction.Text;
            string price = TextBoxPrice.Text;
            int id = 0;
            int id_store = 0;
            DateTime dateTimeDelivery = DateTime.Parse(DeliveryDate); //convert the date in datetime format
            //Check which store is it 
            if (store == "1")
            {
                id_store = 1;
            }
            if (store == "2")
            {
                id_store = 2;
            }
            if (store == "3")
            {
                id_store = 3;
            }

            OpenConnection();
            string query = "SELECT Id_client FROM Client WHERE e_mail = @email"; //get the client id
            MySqlCommand command1 = new MySqlCommand(query, connection);
            command1.CommandText = query;
            command1.Parameters.AddWithValue("@email",email);
            using (MySqlDataReader reader = command1.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Récupérez les données de chaque colonne dans la table Client
                    int id1 = reader.GetInt32(0);
                    id = id1;

                }
            }
            CloseConnection();
            // commande standard
            if(customize == "")
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand("CreateStandardOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    
                    command.Parameters.AddWithValue("@p_Id_Client", id);
                    command.Parameters.AddWithValue("@p_Id_Magasin", id_store);
                    command.Parameters.AddWithValue("@p_Date_commande", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@p_Adresse_livraison", DeliveryAdress);
                    command.Parameters.AddWithValue("@p_Message", description);
                    command.Parameters.AddWithValue("@p_Date_livraison_voulue", dateTimeDelivery);
                    command.Parameters.AddWithValue("@p_Etat_commande", "VINV");
                    command.Parameters.AddWithValue("@p_Type_commande", "Standard");
                    command.Parameters.AddWithValue("@p_Reduction", reduction);

                    command.ExecuteNonQuery();
                }
                
                CloseConnection();
                //actualisation fidelite
                string updateQuery = @"
                UPDATE Client
                SET fidelite = (
                    SELECT CASE
                        WHEN commandes_par_mois > 5 THEN 'Or'
                        WHEN commandes_par_mois >= 1 THEN 'Bronze'
                        ELSE 'Aucun'
                    END
                    FROM (
                        SELECT 
                            COUNT(*) / GREATEST(TIMESTAMPDIFF(MONTH, MIN(Date_commande), NOW()), 1) AS commandes_par_mois
                        FROM Commande WHERE Id_Client = @client_id GROUP BY Id_Client
                    ) AS subquery
                )
                WHERE Id_client = @client_id;";

                using MySqlCommand command3 = new MySqlCommand(updateQuery, connection);
                command3.Parameters.AddWithValue("@client_id", id);
                OpenConnection();
                int rowsAffected = command3.ExecuteNonQuery();
                CloseConnection();
                //TODO actualisation stock
                BoxClear();
            }

            if(customize == "Personalise")
            {
                //todo add sql command for custom order
            }
           
            
        }
    }
}
