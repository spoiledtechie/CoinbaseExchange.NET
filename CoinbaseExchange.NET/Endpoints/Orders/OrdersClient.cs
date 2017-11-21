using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    public class OrdersClient : GenericClient
    {
        public OrdersClient(CBAuthenticationContainer authenticationContainer) : base(authenticationContainer) { }

        public async Task<OrdersResponse> PostOrderMarket(OrdersMarketRequest model)
        {
            var req = new ExchangeRequestGenericBase("POST", "/orders", model);

            return await process<OrdersResponse>(req);
        }

        public async Task<OrdersResponse> DeleteOrderMarket(string orderId)
        {
            var req = new ExchangeRequestGenericBase("DELETE", "/orders/" + orderId);

            return await process<OrdersResponse>(req);
        }
    }
}
