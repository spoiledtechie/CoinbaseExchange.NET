using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    public class OrdersMarketRequest : OrdersBaseRequest
    {
        public OrdersMarketRequest()
        {
            Type = "market";
        }

        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
        [JsonProperty(PropertyName = "funds")]
        public string Funds { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "time_in_force")]
        public string TimeInForce { get; set; }
    }
}
