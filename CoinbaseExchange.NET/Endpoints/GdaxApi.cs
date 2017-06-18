using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.Endpoints.Account;
using CoinbaseExchange.NET.Endpoints.Deposits;
using CoinbaseExchange.NET.Endpoints.Orders;
using CoinbaseExchange.NET.Endpoints.PaymentMethods;
using CoinbaseExchange.NET.Endpoints.Withdrawals;
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

        private OrdersClient _orders;
        public OrdersClient Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersClient(_authSettings);

                return _orders;
            }
        }

        private WithdrawalsClient _withdrawals;
        public WithdrawalsClient Withdrawals
        {
            get
            {
                if (_withdrawals == null)
                    _withdrawals = new WithdrawalsClient(_authSettings);

                return _withdrawals;
            }
        }
    }
}
