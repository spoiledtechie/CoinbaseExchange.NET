using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangeResponseBase
    {
        public ExchangeResponse HttpResponse { get; set; }

        public string BeforePaginationToken { get; set; }
        public string AfterPaginationToken { get; set; }

        private ExchangeResponseBase() { }

        protected ExchangeResponseBase(ExchangeResponse response) {
            HttpResponse = response;

            Debug.WriteLine("Response: " + response.ContentBody);
        }
    }
}
