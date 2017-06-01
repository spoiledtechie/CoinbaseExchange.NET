using CoinbaseExchange.NET.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Deposits
{
    public class DepositsClient : ExchangeClientBase
    {
        public DepositsClient(CBAuthenticationContainer authenticationContainer)
            : base(authenticationContainer)
        {

        }

        public async Task<PaymentMethodResponse> PaymentMethod(
            decimal amount, string currency, string payment_method_id)
        {
            var req = new ExchangeRequestGenericBase("POST", "/deposits/payment-method",
                new { amount, currency, payment_method_id });

            return await process<PaymentMethodResponse>(req);
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
