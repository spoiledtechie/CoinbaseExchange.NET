using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public class HttpExchangeResponse
    {
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; private set; }
        public string ContentBody { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public bool IsSuccessStatusCode { get; private set; }

        public HttpExchangeResponse(
            HttpStatusCode statusCode, 
            bool isSuccess, 
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
            string contentBody)
        {
            this.Headers = headers.ToList();
            this.StatusCode = statusCode;
            this.ContentBody = contentBody;
            this.IsSuccessStatusCode = isSuccess;
        }
    }
}
