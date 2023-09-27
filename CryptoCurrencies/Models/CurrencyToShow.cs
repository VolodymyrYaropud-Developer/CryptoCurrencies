using System.Collections.Generic;

namespace CryptoCurrencies.Models
{
    internal class CurrencyToShow
    {
        public List<CurrencyModel> AllCurrencies { get; set; }
        public List<CurrencyModel> DisplayedCurrencies { get; set; }
        public int DisplayCount { get; set; } = 10;
    }
}
