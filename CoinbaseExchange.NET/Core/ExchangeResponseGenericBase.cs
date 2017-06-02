﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinbaseExchange.NET.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoinbaseExchange.NET.Core
{
    public class ExchangeResponseGenericBase
    {
        public HttpExchangeResponse HttpResponse { get; set; }

        internal virtual void ProcessJson()
        {
            if (HttpResponse.IsSuccessStatusCode)
                JsonConvert.PopulateObject(HttpResponse.ContentBody, this);
        }
    }
}
