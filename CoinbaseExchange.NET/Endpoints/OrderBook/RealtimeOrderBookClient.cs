﻿using CoinbaseExchange.NET.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.OrderBook
{
    public class RealtimeOrderBookClient : ExchangeClientBase
    {
        private readonly string ProductString;

        private object _spreadLock = new object();
        private object _askLock = new object();
        private object _bidLock = new object();

        private List<BidAskOrder> _sells { get; set; }
        private List<BidAskOrder> _buys { get; set; }

        //public decimal CurrentHighBuyPrice { get; set; }
        //public decimal CurrentLowBuyPrice { get; set; }
        //public decimal CurrentHighSellPrice { get; set; }
        //public decimal CurrentLowSellPrice { get; set; }

        public List<BidAskOrder> Sells { get; set; }
        public List<BidAskOrder> SellsPerMinute { get; set; }
        public List<BidAskOrder> SellsPerHour { get; set; }
        public List<BidAskOrder> Buys { get; set; }
        public List<BidAskOrder> BuysPerMinute { get; set; }
        public List<BidAskOrder> BuysPerHour { get; set; }

        public event EventHandler Updated;

        public decimal Spread
        {
            get
            {
                lock (_spreadLock)
                {
                    if (!Buys.Any() || !Sells.Any())
                        return 0;

                    var maxBuy = Buys.Select(x => x.Price).Max();
                    var minSell = Sells.Select(x => x.Price).Min();

                    return minSell - maxBuy;
                }
            }
        }

        public RealtimeOrderBookClient(CBAuthenticationContainer auth, string ProductString) : base(auth)
        {
            this.ProductString = ProductString;
            _sells = new List<BidAskOrder>();
            _buys = new List<BidAskOrder>();

            Sells = new List<BidAskOrder>();
            Buys = new List<BidAskOrder>();

            ResetStateWithFullOrderBook();
        }

        public async void ResetStateWithFullOrderBook()
        {
            try
            {
                var response = await GetProductOrderBook(ProductString, 3);

                lock (_spreadLock)
                {
                    lock (_askLock)
                    {
                        lock (_bidLock)
                        {
                            _buys = response.Buys.ToList();
                            _sells = response.Sells.ToList();

                            Buys = _buys.ToList();
                            Sells = _sells.ToList();
                        }
                    }
                }

                OnUpdated();

                Subscribe(ProductString, OnOrderBookEventReceived);
            }
            catch { }
        }

        private void OnUpdated()
        {
            if (Updated != null)
                Updated(this, new EventArgs());
        }

        public async Task<GetProductOrderBookResponse> GetProductOrderBook(string productId, int level = 1)
        {
            var request = new GetProductOrderBookRequest(productId, level);
            var response = await this.GetResponse(request);
            var orderBookResponse = new GetProductOrderBookResponse(response);
            return orderBookResponse;
        }

        private void OnOrderBookEventReceived(RealtimeMessage message)
        {
            if (message is RealtimeReceived)
            {
                var receivedMessage = message as RealtimeReceived;
                OnReceived(receivedMessage);
            }

            else if (message is RealtimeOpen)
            {

            }

            else if (message is RealtimeDone)
            {
                var doneMessage = message as RealtimeDone;
                OnDone(doneMessage);
            }

            else if (message is RealtimeMatch)
            {

            }

            else if (message is RealtimeChange)
            {

            }

            else if (message is RealtimeOpen)
            {

            }

            OnUpdated();
        }

        private void OnReceived(RealtimeReceived receivedMessage)
        {
            var order = new BidAskOrder();


            if (receivedMessage.Price != null) // no "price" token in market orders
            {
                order.Id = receivedMessage.OrderId;
                order.Price = receivedMessage.Price.Value;
                order.Size = receivedMessage.Size;
                order.Time = DateTime.Now;

                lock (_spreadLock)
                {
                    if (receivedMessage.Side == "buy")
                    {
                        lock (_bidLock)
                        {
                            _buys.Add(order);
                            Buys = _buys.ToList();
                        }
                    }
                    else if (receivedMessage.Side == "sell")
                    {
                        lock (_askLock)
                        {
                            _sells.Add(order);
                            Sells = _sells.ToList();
                        }
                    }
                }
            }
        }

        private void OnDone(RealtimeDone message)
        {
            lock (_spreadLock)
            {
                if (message.Side == "buy")
                {
                    lock (_bidLock)
                    {
                        int count = _buys.RemoveAll(b => b.Id == message.OrderId);
                        if (count > 0)
                            Buys = _buys.ToList();
                    }
                }
                else if (message.Side == "sell")
                {
                    lock (_askLock)
                    {
                        int count = _sells.RemoveAll(a => a.Id == message.OrderId);

                        if (count > 0)
                            Sells = _sells.ToList();
                    }
                }
            }
        }

        private static async void Subscribe(string product, Action<RealtimeMessage> onMessageReceived)
        {
            if (String.IsNullOrWhiteSpace(product))
                throw new ArgumentNullException("product");

            if (onMessageReceived == null)
                throw new ArgumentNullException("onMessageReceived", "Message received callback must not be null.");

            var sandbox_uri = new Uri("wss://ws-feed-public.sandbox.gdax.com");
            var uri = new Uri("wss://ws-feed.gdax.com");
            var webSocketClient = new ClientWebSocket();
            var cancellationToken = new CancellationToken();
            var requestString = String.Format(@"{{""type"": ""subscribe"",""product_id"": ""{0}""}}", product);
            var requestBytes = UTF8Encoding.UTF8.GetBytes(requestString);
            await webSocketClient.ConnectAsync(ExchangeClientBase.IsSandbox ? sandbox_uri : uri, cancellationToken);

            if (webSocketClient.State == WebSocketState.Open)
            {
                var subscribeRequest = new ArraySegment<byte>(requestBytes);
                var sendCancellationToken = new CancellationToken();
                await webSocketClient.SendAsync(subscribeRequest, WebSocketMessageType.Text, true, sendCancellationToken);

                while (webSocketClient.State == WebSocketState.Open)
                {
                    try
                    {
                        var receiveCancellationToken = new CancellationToken();
                        var receiveBuffer = new ArraySegment<byte>(new byte[1024 * 1024 * 5]); // 5MB buffer
                        var webSocketReceiveResult = await webSocketClient.ReceiveAsync(receiveBuffer, receiveCancellationToken);
                        if (webSocketReceiveResult.Count == 0) continue;

                        var jsonResponse = Encoding.UTF8.GetString(receiveBuffer.Array, 0, webSocketReceiveResult.Count);
                        var jToken = JToken.Parse(jsonResponse);

                        var typeToken = jToken["type"];
                        if (typeToken == null) continue;

                        var type = typeToken.Value<string>();
                        RealtimeMessage realtimeMessage = null;

                        switch (type)
                        {
                            case "received":
                                realtimeMessage = new RealtimeReceived(jToken);
                                break;
                            case "open":
                                realtimeMessage = new RealtimeOpen(jToken);
                                break;
                            case "done":
                                realtimeMessage = new RealtimeDone(jToken);
                                break;
                            case "match":
                                realtimeMessage = new RealtimeMatch(jToken);
                                break;
                            case "change":
                                realtimeMessage = new RealtimeChange(jToken);
                                break;
                            case "heartbeat":
                                // + should implement this
                                break;
                            case "error":
                                new RealtimeError(jToken); // + do something with this
                                break;
                            default:
                                break;
                        }

                        if (realtimeMessage == null)
                            continue;

                        onMessageReceived(realtimeMessage);
                    }
                    catch (Exception exception)
                    {

                    }
                }
            }
        }
    }
}
