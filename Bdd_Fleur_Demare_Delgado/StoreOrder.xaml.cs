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
    /// Logique d'interaction pour StoreOrder.xaml
    /// </summary>
    public partial class StoreOrder : Window
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; PORT=3306;DATABASE=fleurs;UID=root;PASSWORD=root");
        private string idStore;
        public StoreOrder()
        {
            InitializeComponent();
        }

        public StoreOrder(string id)
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
        /// Permet d'afficher la liste des commandes
        /// </summary>
        private void AfficherCommande(string date)
        {
            OpenConnection();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Commande WHERE DATE(Date_commande) = @date AND Id_Magasin = @idMagasin;";
            command.Parameters.AddWithValue("@idMagasin", idStore);
            command.Parameters.AddWithValue("@date",date);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGrid.DataContext = dt;
            CloseConnection();
        }
        private void BouttonMAJ_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateCalendrier = (DateTime)cldSample.SelectedDate;
            string date_convert = dateCalendrier.ToString("yyyy-MM-dd");
            string orderid = TextBoxOrderId.Text;
            string Status = TextBoxStatusOrder.Text;
            string description = TextBoxDescription.Text;
            string prix_total = TextBoxPrixMax.Text;
            if(orderid == "")
            {
                AfficherCommande(date_convert);
            }

            if(Status != "")
            {
                OpenConnection();
                MySqlCommand command1 = connection.CreateCommand();
                command1.CommandText = $"UPDATE Commande SET  Etat_commande = @etatCommande WHERE Id_Commande = @idCommande;";
                command1.Parameters.AddWithValue("@prixTotal", prix_total);
                command1.Parameters.AddWithValue("@etatCommande", Status);
                command1.Parameters.AddWithValue("@message", description);
                command1.Parameters.AddWithValue("@idCommande", orderid);
                command1.ExecuteNonQuery();
                CloseConnection();
            }

            if(description != "")
            {
                OpenConnection();
                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = $"UPDATE Commande SET  message = @message WHERE Id_Commande = @idCommande;";
                command2.Parameters.AddWithValue("@message", description);
                command2.Parameters.AddWithValue("@idCommande", orderid);
                command2.ExecuteNonQuery();
                CloseConnection();
            }
            if(prix_total != "")
            {
                OpenConnection();
                MySqlCommand command3 = connection.CreateCommand();
                command3.CommandText = $"UPDATE Commande SET  Prix_total = @prixTotal WHERE Id_Commande = @idCommande;";
                command3.Parameters.AddWithValue("@prixTotal", prix_total);
                command3.Parameters.AddWithValue("@idCommande", orderid);
                command3.ExecuteNonQuery();
                CloseConnection();
            }
            
            AfficherCommande(date_convert);
        }

        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        }
    }
}
