using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Text.Json;

namespace CurrencyLayerApiConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(CurrencyLayerApiConsoleDemo)} _begin");

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var currencylayerAccessKey = config["currencylayer:accessKey"];
            var currencylayerBaseUrl = config["currencylayer:baseUrl"];

            if (currencylayerAccessKey == null) currencylayerAccessKey = "62a94a507bdec33b3f700c8536fb4d39";
            if (currencylayerBaseUrl == null) currencylayerBaseUrl = "http://api.currencylayer.com/live";
            //return;


            var urlBuilder = new CurrencyLayerUrlBuilder(currencylayerBaseUrl);
            urlBuilder.AddAccessKey(currencylayerAccessKey);
            var requestUrl = urlBuilder.Build();

            var client = new RestClient(requestUrl);
            var request = new RestRequest(Method.GET);
            var response = client.Get<CurrencyLayerApiResponse>(request);
            if (response.IsSuccessful)
            {
                if (!response.Data.Success)
                {
                    Console.WriteLine("FAILED");
                }
                var options = new JsonSerializerOptions
                {
                    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                var json = JsonSerializer.Serialize(response.Data, options);
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);
            }

            Console.WriteLine($"{nameof(CurrencyLayerApiConsoleDemo)} ___end");
        }
    }
}
