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

namespace Bdd_Fleur_Demare_Delgado
{
    /// <summary>
    /// Logique d'interaction pour StoreDashboard.xaml
    /// </summary>
    public partial class StoreDashboard : Window
    {
        private string idStore;
        public StoreDashboard()
        {
            InitializeComponent();
        }

        public StoreDashboard(string id)
        {
            InitializeComponent();
            this.idStore = id;
        }

        /// <summary>
        /// Allow to go to the stock window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoStock(object sender, RoutedEventArgs e)
        {
            Stock StockWindow = new Stock(idStore);
            StockWindow.Show();
            this.Close();
        }
        /// <summary>
        /// Allow to go to the Order Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoOrder(object sender, RoutedEventArgs e)
        {
            StoreOrder StoreOrderWindow = new StoreOrder(idStore);
            StoreOrderWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Allow to go to the Stat Window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoStat(object sender, RoutedEventArgs e)
        {
            StoreStat StoreStatWindow = new StoreStat(idStore);
            StoreStatWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Allow to go back to the menu window
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
        /// allow to go to the customer window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GoCustomer(object sender, RoutedEventArgs e)
        {
            StoreCustomer storeCustomerPage = new StoreCustomer(idStore);
            storeCustomerPage.Show();
            this.Close();
        }
    }
}
