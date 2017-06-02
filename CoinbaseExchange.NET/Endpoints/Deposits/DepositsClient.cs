using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Deposits
{
    public class DepositsClient : GenericClient
    {
        public DepositsClient(CBAuthenticationContainer authenticationContainer) : base(authenticationContainer) { }

        public async Task<PaymentMethodResponse> PaymentMethod(
            decimal amount, string currency, string payment_method_id)
        {
            var req = new ExchangeRequestGenericBase("POST", "/deposits/payment-method",
                new { amount, currency, payment_method_id });

            return await process<PaymentMethodResponse>(req);
        }
    }
}
