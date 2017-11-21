﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Core
{
    public abstract class ExchangeClientBase
    {
        public readonly Uri API_SANDBOX_ENDPOINT_URL = new Uri("https://api-public.sandbox.gdax.com");
        public readonly Uri API_ENDPOINT_URL = new Uri("https://api.gdax.com");
        private const string ContentType = "application/json";
        public static bool IsSandbox { get; set; }

        private readonly CBAuthenticationContainer _authContainer;

        public ExchangeClientBase(CBAuthenticationContainer authContainer)
        {
            _authContainer = authContainer;
        }

        protected async Task<HttpExchangeResponse> GetResponse(ExchangeRequestBase request)
        {
            var relativeUrl = request.RequestUrl;
            var absoluteUri = new Uri(IsSandbox ? API_SANDBOX_ENDPOINT_URL : API_ENDPOINT_URL, relativeUrl);

            var timestamp = (request.TimeStamp).ToString(System.Globalization.CultureInfo.InvariantCulture);
            var body = request.RequestBody;
            var method = request.Method;
            var url = absoluteUri.ToString();

            var passphrase = _authContainer.Passphrase;
            var apiKey = _authContainer.ApiKey;

            // Caution: Use the relative URL, *NOT* the absolute one.
            var signature = _authContainer.ComputeSignature(timestamp, relativeUrl, method, body);

            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response;

                    httpClient.DefaultRequestHeaders.Add("CB-ACCESS-KEY", apiKey);
                    httpClient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", signature);
                    httpClient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", timestamp);
                    httpClient.DefaultRequestHeaders.Add("CB-ACCESS-PASSPHRASE", passphrase);

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "sefbkn.github.io");

                    switch (method)
                    {
                        case "GET":
                            response = httpClient.GetAsync(absoluteUri).Result;
                            break;
                        case "DELETE":
                            response = httpClient.DeleteAsync(absoluteUri).Result;
                            break;
                        case "POST":
                            var requestBody = new StringContent(body, Encoding.UTF8, "application/json");
                            response = await httpClient.PostAsync(absoluteUri, requestBody);
                            break;
                        default:
                            throw new NotImplementedException("The supplied HTTP method is not supported: " + method ?? "(null)");
                    }


                    var contentBody = await response.Content.ReadAsStringAsync();
                    var headers = response.Headers.AsEnumerable();
                    var statusCode = response.StatusCode;
                    var isSuccess = response.IsSuccessStatusCode;

                    var genericExchangeResponse = new HttpExchangeResponse(statusCode, isSuccess, headers, contentBody);
                    return genericExchangeResponse;
                }
                catch (Exception exception)
                {
                    throw new Exception("Http Exception", exception);
                }
            }
        }

    }
}
