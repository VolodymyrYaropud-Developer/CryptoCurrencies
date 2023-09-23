using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Models
{
    internal class CurrencyViewModel
    {
        public List<CurrencyModel> AllCurrencies { get; set; }
        public List<CurrencyModel> DisplayedCurrencies { get; set; }
        public int DisplayCount { get; set; } = 10;
    }
}
