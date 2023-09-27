using CryptoCurrencies.Models;
using CryptoCurrencies.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace CryptoCurrencies.View
{
    public partial class MainWindow : Window
    {
        private CurrencyViewModel _viewModel;
        private CurrencyDetailWindow currencyDetailWindow;

        public MainWindow()
        {
            _viewModel = new CurrencyViewModel();
            DataContext = _viewModel;
            SetListViewItemsSource();
            InitializeComponent(); 
        }

        private async void SetListViewItemsSource()
        {
            try
            {
                List<CurrencyModel> currencyData = await _viewModel.DisplayStartCurrency();
                ViewListOfCurrency.ItemsSource = currencyData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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

        private void LoadMoreButton_Click(object sender, RoutedEventArgs e)
        {
            ViewListOfCurrency.ItemsSource = _viewModel.LoadButton();
        }

        private void SearchTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            ViewListOfCurrency.ItemsSource = _viewModel.FindButton(SearchTextBox.Text.ToLower());
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Clear();
        }

        private void ViewListOfCurrency_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ViewListOfCurrency.SelectedItem != null)
            {
                CurrencyModel selectedCurrency = (CurrencyModel)ViewListOfCurrency.SelectedItem;
                var newList = new List<CurrencyModel>
                {
                    selectedCurrency
                };
                currencyDetailWindow = new CurrencyDetailWindow(newList);
                currencyDetailWindow.Show();
                this.Hide();
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ViewListOfCurrency.ItemsSource = _viewModel.GetListOfCurrencies();

        }

        private void SearchTextBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (VisualTreeHelper.HitTest(SearchTextBox, e.GetPosition(SearchTextBox)) == null )
            {
                Keyboard.ClearFocus();
            }
        }
    }
}
