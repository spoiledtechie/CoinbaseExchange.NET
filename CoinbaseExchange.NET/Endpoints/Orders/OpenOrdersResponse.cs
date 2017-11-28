using CoinbaseExchange.NET.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    public class OpenOrdersResponse : ExchangePageableResponseBase
    {
        public IEnumerable<OrdersResponse> Orders { get; private set; }

        public OpenOrdersResponse(HttpExchangeResponse response) : base(response)
        {
            var json = response.ContentBody;
            var jArray = JArray.Parse(json);

            Orders = jArray.Select(elem => JsonConvert.DeserializeObject<OrdersResponse>(elem.ToString())).ToList();
        }
    }
}
