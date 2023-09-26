using CryptoCurrencies.Models.Services;
using CryptoCurrencies.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using CryptoCurrencies.View;
using System.Windows.Controls;
using System.Windows.Media;

namespace CryptoCurrencies.ViewModel
{
    internal class CurrencyViewModel
    {
        public List<CurrencyModel> GetListOfCurrencies()
        {
            return CurrencyWorker._currencyRates.Data;
        }
        public async Task<List<CurrencyModel>> DisplayStartCurrency()
        {
            return await CurrencyWorker.FetchCurrenciesAsync();
        }
        public List<CurrencyModel> LoadButton()
        {
            return CurrencyWorker.LoadMoreButtonFunc();
        }
        public List<CurrencyModel> FindButton(string str)
        {
            return CurrencyWorker.FindCurrencyBySymbolAndName(str);
        }

    }
    
}
