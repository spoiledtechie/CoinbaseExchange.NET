using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinbaseExchange.NET.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CoinbaseExchange.NET.Core;

namespace CoinbaseExchange.NET.CoreGenerics
{
    public class ExchangeResponseGenericBase
    {
        public HttpExchangeResponse HttpResponse { get; set; }

        internal virtual void ProcessJson()
        {

            if (HttpResponse.IsSuccessStatusCode)
            {
                try
                {
                    JsonConvert.PopulateObject(HttpResponse.ContentBody, this);
                }
                catch (Exception exception)
                {
               //Log.Error     throw new Exception("Can't Populate:" + HttpResponse.ContentBody, exception);
                }
            }
        }
    }
}
