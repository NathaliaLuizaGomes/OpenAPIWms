using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Models.Integrations
{
    public class CryptoAPIResponseModelItens
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "nameid")]
        public string nameid { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int rank { get; set; }

        [JsonProperty(PropertyName = "price_usd")]
        public string price_usd { get; set; }

        [JsonProperty(PropertyName = "percent_change_24h")]
        public string percent_change_24h { get; set; }

        [JsonProperty(PropertyName = "percent_change_1h")]
        public string percent_change_1h { get; set; }

        [JsonProperty(PropertyName = "percent_change_7d")]
        public string percent_change_7d { get; set; }

        [JsonProperty(PropertyName = "price_btc")]
        public string price_btc { get; set; }

        [JsonProperty(PropertyName = "market_cap_usd")]
        public string market_cap_usd { get; set; }

        [JsonProperty(PropertyName = "volume24")]
        public float volume24 { get; set; }

        [JsonProperty(PropertyName = "volume24a")]
        public float volume24a { get; set; }

        [JsonProperty(PropertyName = "csupply")]
        public string csupply { get; set; }

        [JsonProperty(PropertyName = "tsupply")]
        public string tsupply { get; set; }

        [JsonProperty(PropertyName = "msupply")]
        public string msupply { get; set; }
    }
}
