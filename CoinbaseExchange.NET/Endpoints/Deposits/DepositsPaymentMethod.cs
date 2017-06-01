using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Deposits
{
    public class DepositsPaymentMethod
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PayoutAt { get; set; }

        public DepositsPaymentMethod(JToken jToken)
        {
            this.Id = jToken["id"].Value<string>();
            this.Amount = jToken["amount"].Value<decimal>();
            this.Currency = jToken["currency"].Value<string>();
            this.PayoutAt = jToken["payout_at"].Value<DateTime>();
        }
    }
}
