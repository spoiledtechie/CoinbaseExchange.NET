using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    
    public class OrdersResponse : ExchangeResponseGenericBase
    {
        public string Id { get; set; }
        /// <summary>
        /// price of which we bought this order at.
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// we need the group id to match the BUY order, with the sell order.
        /// so I can quickly search for the buy order to see what it was purchased at
        /// then make a decision of how to adjust the sell if needed.
        /// </summary>
        public Guid GroupId { get; set; }

        public decimal Price { get; set; }
        public decimal Size { get; set; }
        [JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }
        public string Side { get; set; }
        public string Stp { get; set; } // Self-trade prevention flag
        public string Type { get; set; }
        [JsonProperty(PropertyName = "time_in_force")]
        public string TimeInForce { get; set; }
        [JsonProperty(PropertyName = "post_only")]
        public bool PostOnly { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "fill_fees")]
        public decimal FillFees { get; set; }
        [JsonProperty(PropertyName = "filled_size")]
        public decimal FilledSize { get; set; }
        [JsonProperty(PropertyName = "executed_value")]
        public decimal ExecutedValue { get; set; }
        public string Status { get; set; }
        public bool Settled { get; set; }
    }
}
