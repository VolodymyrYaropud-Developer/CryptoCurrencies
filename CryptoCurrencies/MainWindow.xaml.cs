using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


namespace CryptoCurrencies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var data = new TestData.Data();
            ViewListOfCurrency.ItemsSource = data.someCurrency;
        }
        private ListView DataView()
        {
            var values = new TestData.Data().someCurrency;
            var listView = new ListView();
            foreach (var coin in values)
            {
                listView.Items.Add(coin);
            }
            return listView;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim().ToLower();
            var filteredCoins = new TestData.Data().someCurrency.
                Where(coin => coin.Name.ToLower().Contains(searchText)|| coin.Symbol.ToLower().Contains(searchText)).
                ToList();
            ViewListOfCurrency.ItemsSource = filteredCoins;
        }
    }
}
