using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.CoreGenerics
{
    public class GenericClient : ExchangeClientBase
    {
        public GenericClient(CBAuthenticationContainer authContainer) : base(authContainer) { }

        protected async Task<T> process<T>(ExchangeRequestGenericBase request)
            where T : ExchangeResponseGenericBase, new()
        {
            var response = await this.GetResponse(request);

            var result = new T();
            result.HttpResponse = response;
            result.ProcessJson();

            return result;
        }
    }
}
