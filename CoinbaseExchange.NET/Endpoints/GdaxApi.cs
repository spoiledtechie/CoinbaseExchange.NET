using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.Endpoints.Account;
using CoinbaseExchange.NET.Endpoints.Deposits;
using CoinbaseExchange.NET.Endpoints.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints
{
    public class GdaxApi
    {
        public GdaxApi(CBAuthenticationContainer authSettings)
        {
            _authSettings = authSettings;
        }

        private CBAuthenticationContainer _authSettings;

        private DepositsClient _deposits;
        public DepositsClient Deposits
        {
            get
            {
                if (_deposits == null)
                    _deposits = new DepositsClient(_authSettings);

                return _deposits;
            }
        }

        private AccountClient _account;
        public AccountClient Account
        {
            get
            {
                if (_account == null)
                    _account = new AccountClient(_authSettings);

                return _account;
            }
        }

        private PaymentMethodsClient _paymentMethods;
        public PaymentMethodsClient PaymentMethods
        {
            get
            {
                if (_paymentMethods == null)
                    _paymentMethods = new PaymentMethodsClient(_authSettings);

                return _paymentMethods;
            }
        }
    }
}
