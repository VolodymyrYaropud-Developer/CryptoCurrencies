using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Models
{
    public class CurrencyModel
    {
        public string? Id { get; set; }
        public string? rank { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? supply { get; set; }
        public string? maxSupply { get; set; }
        public string? marketCapUsd { get; set; }
        public string? volumeUsd24Hr { get; set; }
        public string? PriceUsd { get; set; }
        public string? changePercent24Hr { get; set; }
        public string? vwap24Hr { get; set; }
    }
    public class CurrencyRates
    {
        public List<CurrencyModel>? Data { get; set; }
    }
}
