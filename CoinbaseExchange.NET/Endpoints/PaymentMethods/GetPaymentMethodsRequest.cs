using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PaymentMethods
{
	public class GetPaymentMethodsRequest : ExchangeRequestBase
	{
		public GetPaymentMethodsRequest()
			: base("GET")
		{
			var urlFormat = String.Format("/payment-methods");
			this.RequestUrl = urlFormat;
		}
	}
}
