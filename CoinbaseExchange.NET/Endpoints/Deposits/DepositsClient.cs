using CoinbaseExchange.NET.Core;
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

        public async Task<PostDepositsPaymentMethodResponse> PostDepositsPaymentMethodAsync(
            decimal amount, string currency, string payment_method_id)
        {
            var request = new PostDepositsPaymentMethodRequest(amount, currency, payment_method_id);
            var response = await this.GetResponse(request);
            var productsResponse = new PostDepositsPaymentMethodResponse(response);
            return productsResponse;
        }
    }
}
