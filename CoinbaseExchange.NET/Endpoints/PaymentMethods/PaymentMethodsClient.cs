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
            var req = new ExchangeRequestGenericBase("GET", "/payment-methods");

            return await process<GetPaymentMethodsResponse>(req);
        }

        private async Task<T> process<T>(ExchangeRequestGenericBase request)
            where T : ExchangeResponseGenericBase, new()
        {
            var response = await this.GetResponse(request);

            var result = new T();
            result.HttpResponse = response;
            result.ProcessJson();

            return result;
        }
    }
}
