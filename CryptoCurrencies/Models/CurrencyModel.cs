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
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? Explorer { get; set; }
        public double PriceUsd { get; set; }
    }
    public class CurrencyRates
    {
        public List<CurrencyModel>? Data { get; set; }
        public long? Timestamp { get; set; }
    }
}
