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
    public class PostDepositsPaymentMethodResponse : ExchangeResponseBase
    {
        public DepositsPaymentMethod Result { get; private set; }

        public PostDepositsPaymentMethodResponse(ExchangeResponse response) : base(response)
        {
            if (response.IsSuccessStatusCode)
                Result = new DepositsPaymentMethod(JToken.Parse(response.ContentBody));
        }
    }
}
