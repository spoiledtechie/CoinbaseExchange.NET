using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinbaseExchange.NET.Utilities;
using Newtonsoft.Json;
using CoinbaseExchange.NET.Core;

namespace CoinbaseExchange.NET.CoreGenerics
{
    public class ExchangeRequestGenericBase : ExchangeRequestBase
    {
        public ExchangeRequestGenericBase(string method, string url, object requestBody = null)
            : base(method)
        {

            RequestUrl = url;

            if (requestBody != null)
                RequestBody = JsonConvert.SerializeObject(requestBody);
        }
    }
}
