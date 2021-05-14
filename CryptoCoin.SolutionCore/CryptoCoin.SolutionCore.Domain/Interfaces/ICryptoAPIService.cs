using CryptoCoin.SolutionCore.Domain.Models.Integrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoin.SolutionCore.Domain.Interfaces
{
    public interface ICryptoAPIService
    {
        List<CryptoAPIResponseModelItens> SearchCoins();
        List<CryptoAPIResponseModelItens> SearchCoinsTradeId(int id);
        List<CryptoAPIResponseModelItens> SearchCoinsToId(int id);
        List<CryptoAPIResponseModelForMarkets> SearchForMarket(int tradeId);
    }
}
