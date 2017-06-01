using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public class ExchangeResponseBase
    {
        public string BeforePaginationToken { get; set; }
        public string AfterPaginationToken { get; set; }

        [Obsolete]
        private ExchangeResponseBase() { }

        [Obsolete]
        protected ExchangeResponseBase(HttpExchangeResponse response) { }
    }
}
