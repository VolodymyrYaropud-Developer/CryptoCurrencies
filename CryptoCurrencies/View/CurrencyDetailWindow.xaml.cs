using CryptoCurrencies.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CryptoCurrencies.View
{
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
            mainWindow.Show();
        }
        private void changePercentTextPercent_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is TextBlock textBlock)
            {
                if (double.TryParse(textBlock.Text, out double changePercent) && changePercent >= 0)
                    textBlock.Foreground = Brushes.Green;
                else
                    textBlock.Foreground = Brushes.Red;
                textBlock.Text = textBlock.Text.Substring(0, 4) + " %";
            }
        }
    }
}
