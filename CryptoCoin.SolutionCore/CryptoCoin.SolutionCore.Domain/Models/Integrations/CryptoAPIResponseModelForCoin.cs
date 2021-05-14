using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Models.Integrations
{
    public class CryptoAPIResponseModelForCoin
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public string quote { get; set; }

        [JsonProperty(PropertyName = "price")]
        public float price { get; set; }

        [JsonProperty(PropertyName = "price_usd")]
        public float price_usd { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public float volume { get; set; }

        [JsonProperty(PropertyName = "volume_usd")]
        public float volume_usd { get; set; }

        [JsonProperty(PropertyName = "time")]
        public int time { get; set; }
    }
}
