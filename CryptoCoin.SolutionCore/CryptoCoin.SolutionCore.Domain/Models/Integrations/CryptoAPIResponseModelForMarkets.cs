using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Models.Integrations
{
    public class CryptoAPIResponseModelForMarkets
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "quote")]
        public string quote { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string price { get; set; }

        [JsonProperty(PropertyName = "price_usd")]
        public string price_usd { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public string volume { get; set; }

        [JsonProperty(PropertyName = "volume_usd")]
        public string volume_usd { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string time { get; set; }
    }
}
