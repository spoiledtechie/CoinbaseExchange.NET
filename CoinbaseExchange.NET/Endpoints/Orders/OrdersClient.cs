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
    }
}
