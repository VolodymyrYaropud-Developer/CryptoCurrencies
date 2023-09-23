using CryptoCurrencies.Models;
using CryptoCurrencies.ViewModel;
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

namespace CryptoCurrencies.View
{
    /// <summary>
    /// Interaction logic for CurrencyDetailWindow.xaml
    /// </summary>
    public partial class CurrencyDetailWindow : Window
    {
        public CurrencyDetailWindow(List<CurrencyModel> currencyModels)
        {
            InitializeComponent();

            DataContext = currencyModels; 
            ViewListOfCurrencyItem.ItemsSource = currencyModels;
        }
    }
}
