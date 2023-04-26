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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void GoClient(object sender, RoutedEventArgs e)
        {
            ClientConnexion ClientPageConnexion = new ClientConnexion();
            ClientPageConnexion.Show();
            this.Close();
        }


        private void GoEntreprise(object sender, RoutedEventArgs e)
        {
            //Entreprise pageEntreprise = new Entreprise();
            //pageEntreprise.Show();
            //this.Close();
        }

    }
}
