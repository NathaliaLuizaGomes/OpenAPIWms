using CryptoCoin.SolutionCore.Domain.Interfaces;
using CryptoCoin.SolutionCore.Domain.Models.Integrations;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Services
{
    public class CryptoAPIService : ICryptoAPIService
    {
        private static readonly HttpClient client = new HttpClient();

        public List<CryptoAPIResponseModelItens> SearchCoins()
        {

            var coins = new RestClient("https://api.coinlore.net/api/tickers/");
            coins.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            // Deserializa para o objeto de resposta..
            IRestResponse<List<CryptoAPIResponseModel>> response = coins.Execute<List<CryptoAPIResponseModel>>(request);

            string json = response.Content;

            var coinsList = JsonConvert.DeserializeObject<CryptoAPIResponseModel>(json);

            if (response.IsSuccessful)
            {
                return coinsList.Data;
            }

            return null;

        }

        public List<CryptoAPIResponseModelItens> SearchCoinsTradeId(int id)
        {

            var coins = new RestClient("https://api.coinlore.net/api/ticker/?id=" + id);
            coins.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            // Deserializa para o objeto de resposta..
            IRestResponse<List<CryptoAPIResponseModelItens>> response = coins.Execute<List<CryptoAPIResponseModelItens>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;

        }

        public List<CryptoAPIResponseModelItens> SearchCoinsToId(int id)
        {

            var coins = new RestClient("https://api.coinlore.net/api/ticker/?id=" + id);
            coins.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            // Deserializa para o objeto de resposta..
            IRestResponse<List<CryptoAPIResponseModelItens>> response = coins.Execute<List<CryptoAPIResponseModelItens>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;

        }

        public List<CryptoAPIResponseModelForMarkets> SearchForMarket(int tradeId)
        {
            var coins = new RestClient("https://api.coinlore.net/api/coin/markets/?id=" + tradeId);
            coins.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            // Deserializa para o objeto de resposta..
            IRestResponse<List<CryptoAPIResponseModelForMarkets>> response = coins.Execute<List<CryptoAPIResponseModelForMarkets>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;
        }

    }
}
