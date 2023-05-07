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

        /// <summary>
        /// Button to manage orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //SET status of an order 
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
                //Manage custom order
                OpenConnection();
                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = $"UPDATE Commande SET  message = @message WHERE Id_Commande = @idCommande;";
                command2.Parameters.AddWithValue("@message", description);
                command2.Parameters.AddWithValue("@idCommande", orderid);
                command2.ExecuteNonQuery();
                CloseConnection();
                List<String> SplitString = description.Split(';').ToList() ; //List of the messsage split
                List<String> ProductIdList = new List<String>(); //List of product id
                List<String> ProductQuantity = new List<String>(); //List of quantity by product
                int size = SplitString.Count();
                if(size % 2 == 0) //If size % 2 != 0 it means that the user didn't respect the format which is "NameOfTheProduct;Quantity of it"
                {
                    for(int i = 0;i < size/2; i++)
                    {
                        string itemName = SplitString[2*i];
                        OpenConnection();
                        MySqlCommand command3 = connection.CreateCommand();
                        command3.CommandText = $"SELECT Id_Produit FROM Produit WHERE Nom = @nom_produit"; // Have the id of product by the name of it
                        command3.Parameters.AddWithValue("@nom_produit", itemName);
                        command3.ExecuteNonQuery();
                        string productId = command3.ExecuteScalar().ToString();
                        CloseConnection();
                        ProductIdList.Add(productId);
                        string itemQuantity = SplitString[2*i + 1];
                        ProductQuantity.Add(itemQuantity);
                    }
                    int size2 = ProductIdList.Count();
                    for(int j = 0; j < size2;j++)
                    {
                        string Id_produit = ProductIdList[j];
                        string quantity = ProductQuantity[j];
                        //Insert each product with its quantity
                        OpenConnection();
                        MySqlCommand command4 = connection.CreateCommand();
                        command4.CommandText = $"INSERT INTO Commande_Produit(Id_Commande, Id_Produit, Quantite) VALUES(@Id_Commande, @Id_Produit, @Quantite);";
                        command4.Parameters.AddWithValue("@Id_Commande", orderid);
                        command4.Parameters.AddWithValue("@Id_Produit", Id_produit);
                        command4.Parameters.AddWithValue("@Quantite", quantity);
                        command4.ExecuteNonQuery();
                        CloseConnection();

                    }
                    //Update Stock
                    OpenConnection();
                    MySqlCommand command5 = connection.CreateCommand();
                    command5.CommandText = @"
    UPDATE Stock s
    JOIN Commande_Produit cp ON s.Id_Produit = cp.Id_Produit
    JOIN Commande c ON s.Id_Magasin = c.Id_Magasin
    SET s.Quantite = s.Quantite - cp.Quantite
    WHERE cp.Id_Commande = @Id_Commande AND c.Id_Commande = @Id_Commande;
";
                    command5.Parameters.AddWithValue("@Id_Commande", orderid);
                    command5.ExecuteNonQuery();
                    CloseConnection();

                }
                
            }
            //Update Price
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
        /// <summary>
        /// Button to go back to the dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BouttonMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreDashboard NewStoreDashboardPage = new StoreDashboard(idStore);
            NewStoreDashboardPage.Show();
            this.Close();
        }
    }
}
