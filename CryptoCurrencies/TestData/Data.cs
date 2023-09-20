using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.TestData
{
    public class Data
    {
        public class ModelOfData
        {
            public string Name { get; set; }
            public string Symbol { get; set; }
            public double Price { get; set; }
            public ModelOfData(string name, string s, double price)
            {
                Name = name;
                Symbol = s;
                Price = price;
            }
        }
        public List<ModelOfData> someCurrency = new List<ModelOfData>();
        public Data()
        {
            someCurrency.Add(new ModelOfData("bitcoin", "BTC", 0.001));
            someCurrency.Add(new ModelOfData("ethereum", "ETH", 404.9774667045200896));
            someCurrency.Add(new ModelOfData("ripple", "XRP", 0.4202870472643482));
        }
    }
}
