using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
	public class GetPaymentMethodsResponse : ExchangeResponseGenericListBase<GetPaymentMethodsResponse.ContentItem>
    {
        public class ContentItem
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Currency { get; set; }
            [JsonProperty(PropertyName = "primary_buy")]
            public bool PrimaryBuy { get; set; }
            [JsonProperty(PropertyName = "primary_sell")]
            public bool PrimarySell { get; set; }
            [JsonProperty(PropertyName = "allow_buy")]
            public bool AllowBuy { get; set; }
            [JsonProperty(PropertyName = "allow_sell")]
            public bool AllowSell { get; set; }
            [JsonProperty(PropertyName = "allow_deposit")]
            public bool AllowDeposit { get; set; }
            [JsonProperty(PropertyName = "allow_withdraw")]
            public bool AllowWithdraw { get; set; }
        }
    }
}
