using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
    // https://docs.gdax.com/#payment-methods
    public class PaymentMethods
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public bool PrimaryBuy { get; set; }
        public bool PrimarySell { get; set; }
        public bool AllowBuy { get; set; }
        public bool AllowSell { get; set; }
        public bool AllowDeposit { get; set; }
        public bool AllowWithdraw { get; set; }

        // TODO: limits

        public PaymentMethods(JToken jToken)
        {
            this.Id = jToken["id"].Value<string>();
            this.Type = jToken["type"].Value<string>();
            this.Name = jToken["name"].Value<string>();
            this.Currency = jToken["currency"].Value<string>();
            this.PrimaryBuy = jToken["primary_buy"].Value<bool>();
            this.PrimarySell = jToken["primary_sell"].Value<bool>();
            this.AllowBuy = jToken["allow_buy"].Value<bool>();
            this.AllowSell = jToken["allow_sell"].Value<bool>();
            this.AllowDeposit = jToken["allow_deposit"].Value<bool>();
            this.AllowWithdraw = jToken["allow_withdraw"].Value<bool>();
        }
    }
}
