using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    public abstract class OrdersBaseRequest
    {
        [JsonProperty(PropertyName = "client_oid")]
        public string ClientOid { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }
        [JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName = "stp")]
        public string Stp { get; set; }
    }
}
