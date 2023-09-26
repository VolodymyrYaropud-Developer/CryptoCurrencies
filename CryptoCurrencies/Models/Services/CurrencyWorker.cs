﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace CryptoCurrencies.Models.Services
{
    internal static class CurrencyWorker
    {
        public static CurrencyRates _currencyRates {  get; private set; }
        
        private static CurrencyToShow viewModel = new CurrencyToShow();
        public static async Task<List<CurrencyModel>> FetchCurrenciesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.coincap.io/v2/assets");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    _currencyRates = JsonConvert.DeserializeObject<CurrencyRates>(responseBody);
                    //GetCurrencyByName();
                    return _currencyRates.Data.Take(viewModel.DisplayCount).ToList();
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("Failed to fetch currencies: " + ex.Message, ex);
                }
                catch (JsonException ex)
                {
                    throw new Exception("Failed to parse JSON: " + ex.Message, ex);
                }
            }
        }
        public static async Task<List<CurrencyModel>> GetCurrencyByName(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.coincap.io/v2/assets/{name}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            _currencyRates = JsonConvert.DeserializeObject<CurrencyRates>(responseBody);
            return _currencyRates.Data;
        }

        public static List<CurrencyModel> LoadMoreButtonFunc()
        {
            try
            {
                viewModel.DisplayCount += 10;
                return _currencyRates.Data.Take(viewModel.DisplayCount).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Server error {ex.Message}");
                return default;
            }
        }

        public static  List<CurrencyModel> FindCurrencyBySymbolAndName(string str) 
        {
            return _currencyRates.Data.FindAll(s=> s.Name.ToLower() == str|| s.Symbol.ToLower()== str);
        }
    }
}
