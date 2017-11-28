using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Orders
{
    public class OpenOrdersRequest : ExchangePageableRequestBase
    {
        public OpenOrdersRequest(
            ) : base("GET")
        {
            var urlFormat = String.Format("/orders");
            this.RequestUrl = urlFormat;
        }
    }
}
