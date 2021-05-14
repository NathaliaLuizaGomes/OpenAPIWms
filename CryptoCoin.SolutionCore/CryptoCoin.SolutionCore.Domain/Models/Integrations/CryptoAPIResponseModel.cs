using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Models.Integrations
{
    public class CryptoAPIResponseModel
    {
        [JsonProperty(PropertyName = "data")]
        public List<CryptoAPIResponseModelItens> Data { get; set; }

        [JsonProperty(PropertyName = "datacoin")]
        public CryptoAPIResponseModelForCoin DataCoin { get; set; }
    }
}
