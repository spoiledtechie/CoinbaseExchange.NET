using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinbaseExchange.NET.Endpoints.OrderBook;
using CoinbaseExchange.NET.Core;
using System.Configuration;

namespace CoinbaseExchange.Tests.OrderBook
{
    [TestClass]
    public class OrderBookTest
    {
        [TestMethod]
        public void TestGetProductOrderBook()
        {
            RealtimeOrderBookClient client = new RealtimeOrderBookClient(GetAuthenticationContainer(), "BTC-USD");
            var orderBook = client.GetProductOrderBook("BTC-USD", 1);

        }
        private CBAuthenticationContainer GetAuthenticationContainer()
        {
            var authenticationContainer = new CBAuthenticationContainer(
              ConfigurationManager.AppSettings["apikey"], // API Key
              ConfigurationManager.AppSettings["passphrase"], // Passphrase
             ConfigurationManager.AppSettings["secretkey"]// Secret
            );

            return authenticationContainer;
        }
    }
}
