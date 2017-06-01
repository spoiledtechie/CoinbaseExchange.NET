using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
	public class GetPaymentMethodsResponse : ExchangeResponseBase
    {
        public IEnumerable<PaymentMethods> PaymentMethods { get; private set; }

        public GetPaymentMethodsResponse(ExchangeResponse response) : base(response)
        {
            var json = response.ContentBody;
            var jArray = JArray.Parse(json);
            PaymentMethods = jArray.Select(elem => new PaymentMethods(elem)).ToList();
        }
    }
}
