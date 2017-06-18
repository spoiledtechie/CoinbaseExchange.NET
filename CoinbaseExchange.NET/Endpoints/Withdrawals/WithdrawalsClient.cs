using CoinbaseExchange.NET.Core;
using CoinbaseExchange.NET.CoreGenerics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.Withdrawals
{
    public class WithdrawalsClient : GenericClient
    {
        public WithdrawalsClient(CBAuthenticationContainer authenticationContainer) : base(authenticationContainer) { }

        public async Task<WithdrawalResponse> PaymentMethod(
            decimal amount, string currency, string payment_method_id)
        {
            var req = new ExchangeRequestGenericBase("POST", "/withdrawals/payment-method",
                new { amount, currency, payment_method_id });

            return await process<WithdrawalResponse>(req);
        }

        public async Task<WithdrawalResponse> Coinbase(
            decimal amount, string currency, string coinbase_account_id)
        {
            var req = new ExchangeRequestGenericBase("POST", "/withdrawals/coinbase",
                new { amount, currency, coinbase_account_id });

            return await process<WithdrawalResponse>(req);

        }
        public async Task<WithdrawalResponse> Crypto(
            decimal amount, string currency, string crypto_address)
        {
            var req = new ExchangeRequestGenericBase("POST", "/withdrawals/crypto",
                new { amount, currency, crypto_address });

            return await process<WithdrawalResponse>(req);
        }
    }
}
