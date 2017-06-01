using CoinbaseExchange.NET.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Deposits
{
    public class PostDepositsPaymentMethodRequest : ExchangeRequestBase
    {
        public PostDepositsPaymentMethodRequest(decimal amount, string currency, string payment_method_id)
            : base("POST")
        {
            var urlFormat = String.Format("/deposits/payment-method");
            this.RequestUrl = urlFormat;

            var request = new
            {
                amount,
                currency,
                payment_method_id
            };

            this.RequestBody = JsonConvert.SerializeObject(request);
        }
    }
}
