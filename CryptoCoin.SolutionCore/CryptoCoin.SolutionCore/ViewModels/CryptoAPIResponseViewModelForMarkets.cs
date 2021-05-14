using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCoin.SolutionCore.ViewModels
{
    public class CryptoAPIResponseViewModelForMarkets
    {

        public string name { get; set; }
        public string Base { get; set; }
        public string quote { get; set; }
        public string price { get; set; }
        public string price_usd { get; set; }
        public string volume { get; set; }
        public string volume_usd { get; set; }
        public string time { get; set; }
        public DateTime TimeRequest { get; set; }

        public CryptoAPIResponseViewModelForMarkets()
        {
            TimeRequest = DateTime.Now;
        }


    }
}
