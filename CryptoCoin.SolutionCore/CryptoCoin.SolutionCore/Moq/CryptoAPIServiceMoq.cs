using CryptoCoin.SolutionCore.Domain.Interfaces;
using CryptoCoin.SolutionCore.Domain.Models.Integrations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCoin.SolutionCore.Moq
{
    public class CryptoAPIServiceMoq
    {
        private readonly ICryptoAPIService _cryptoAPIService;

        public CryptoAPIServiceMoq(ICryptoAPIService _cryptoAPIService)
        {
            this._cryptoAPIService = _cryptoAPIService;
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
    }
}
