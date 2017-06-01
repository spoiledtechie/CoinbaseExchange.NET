using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
    public class PaymentMethodsClient : ExchangeClientBase
    {
        public PaymentMethodsClient(CBAuthenticationContainer authenticationContainer)
            : base(authenticationContainer)
        {

        }

        public async Task<GetPaymentMethodsResponse> GetPaymentMethodsAsync()
        {
            var request = new GetPaymentMethodsRequest();
            var response = await this.GetResponse(request);
            var productsResponse = new GetPaymentMethodsResponse(response);
            return productsResponse;
        }
    }
}
