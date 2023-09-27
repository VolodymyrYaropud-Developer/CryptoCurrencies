using CryptoCurrencies.Models.Services;
using CryptoCurrencies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
