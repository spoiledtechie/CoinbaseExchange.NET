using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
    public class PaymentMethodsClient : GenericClient
    {
        public PaymentMethodsClient(CBAuthenticationContainer authenticationContainer) : base(authenticationContainer) { }

        public async Task<GetPaymentMethodsResponse> GetPaymentMethodsAsync()
        {
            var req = new ExchangeRequestGenericBase("GET", "/payment-methods");

            return await process<GetPaymentMethodsResponse>(req);
        }
    }
}
