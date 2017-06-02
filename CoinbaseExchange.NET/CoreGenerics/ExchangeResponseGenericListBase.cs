using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinbaseExchange.NET.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoinbaseExchange.NET.CoreGenerics
{
    public class ExchangeResponseGenericListBase<T> : ExchangeResponseGenericBase
    {
        public List<T> Items { get; set; }

        internal override void ProcessJson()
        {
            if (HttpResponse.IsSuccessStatusCode)
                Items = JsonConvert.DeserializeObject<List<T>>(HttpResponse.ContentBody);
        }
    }
}
