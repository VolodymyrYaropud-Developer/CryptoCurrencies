using CryptoCurrencies.Models;
using System;
using System.Collections.Generic;

using System.Windows;


namespace CryptoCurrencies.View
{
    /// <summary>
    /// Interaction logic for CurrencyDetailWindow.xaml
    /// </summary>
    public partial class CurrencyDetailWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        public CurrencyDetailWindow(List<CurrencyModel> currencyModels)
        {
            InitializeComponent();

            DataContext = currencyModels; 
            ViewListOfCurrencyItem.ItemsSource = currencyModels;
        }

        private void ButtonToBackOnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            Close();
        }
        private void CurrencyDetailWindow_Closed(object sender, EventArgs e)
        {
            // Show the main window
            mainWindow.Show();
        }

    }
}
