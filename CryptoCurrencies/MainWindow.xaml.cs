using CryptoCurrencies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;


namespace CryptoCurrencies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyRates _currencyRates;
        private CurrencyViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Start();

        }
        private async void Start()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responce = await client.GetAsync($"https://api.coincap.io/v2/assets");
                    responce.EnsureSuccessStatusCode();
                    if (responce.IsSuccessStatusCode)
                    {
                        Desirialize(responce);
                        _currencyRates.Data = _currencyRates.Data;
                        viewModel = new CurrencyViewModel
                        {
                            AllCurrencies = _currencyRates.Data,
                            DisplayedCurrencies = _currencyRates.Data.Take(10)
                            .ToList()
                        };
                        DataContext = viewModel.DisplayedCurrencies;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Server error {ex.Message}");
                }
            }
        }
        private async void Desirialize(HttpResponseMessage responce)
        {
            try
            {
                string responseBody = await responce.Content.ReadAsStringAsync();
                _currencyRates = JsonConvert.DeserializeObject<CurrencyRates>(responseBody);
                List<CurrencyModel> cryptocurrencies = _currencyRates.Data;
                var timestamp = _currencyRates.Timestamp;
                var temp = new List<CurrencyRates>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Server error {ex.Message}");
            }
        }

        private void LoadMoreButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.DisplayCount += 10;
                DataContext = _currencyRates.Data.Take(viewModel.DisplayCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Server error {ex.Message}");
            }
        }
    }
}
