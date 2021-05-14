using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoCoin.SolutionCore.ViewModels
{
    public class CryptoAPIResponseViewModelForMarketsFilter
    {
        public int TradeId { get; set; }
        public int ToId { get; set; }
        public string Quote { get; set; }

        public List<CryptoAPIResponseViewModelForMarkets> Index { get; set; }
    }
}
