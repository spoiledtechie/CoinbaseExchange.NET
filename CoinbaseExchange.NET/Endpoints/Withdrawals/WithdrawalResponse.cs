using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Withdrawals
{
    public class WithdrawalResponse : ExchangeResponseGenericBase
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "payout_at")]
        public DateTime PayoutAt { get; set; }
    }
}
