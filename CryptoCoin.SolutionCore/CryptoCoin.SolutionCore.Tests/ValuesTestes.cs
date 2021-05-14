using CryptoCoin.SolutionCore.Domain.Interfaces;
using CryptoCoin.SolutionCore.Domain.Models.Integrations;
using CryptoCoin.SolutionCore.Domain.Services;
using CryptoCoin.SolutionCore.Moq;
using CryptoCoin.SolutionCore.Tests.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CryptoCoin.SolutionCore.Tests
{
    public class ValuesTestes
    {

        private readonly TesteContext _testeContext;
        private Mock<ICryptoAPIService> mock;
        private const int ToIdValido = 90;
        private const int ToIdInValido = 0;

        public ValuesTestes()
        {
            _testeContext = new TesteContext();
            mock = new Mock<ICryptoAPIService>(MockBehavior.Strict);

            mock.Setup(s => s.SearchCoinsToId(ToIdValido)).Returns(() => null);
            mock.Setup(s => s.SearchCoinsToId(ToIdInValido)).Throws(new Exception("Moeda inexistente"));
        }

        private List<CryptoAPIResponseModelItens> ObterDadosMoeda(int moeda)
        {
            CryptoAPIServiceMoq analise = new CryptoAPIServiceMoq(mock.Object);
            return analise.SearchCoinsToId(moeda);
        }

        [Fact]
        public void TestarMoedaValidaMoq()
        {
            List<CryptoAPIResponseModelItens> valor =
                ObterDadosMoeda(ToIdValido);
            valor.AsReadOnly();

        }

        [Fact]
        public async Task Values_Get_ReturnOkResponse()
        {
            var response = await _testeContext.Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            response.StatusCode.GetType();

        }

        [Fact]
        public async Task Values_Get_ReturnOkResponse_PartialTable()
        {
            var response = await _testeContext.Client.GetAsync("Crypto/_PartialTable/?tradeId=90&toId=80");
            response.EnsureSuccessStatusCode();
            response.StatusCode.GetType();

        }

        [Fact]
        public async Task Values_Get_ReturnOkResponse_PartialConversionCoin()
        {
            var response = await _testeContext.Client.GetAsync("Crypto/_PartialConversionCoin/?tradeId=90&toId=80");
            response.EnsureSuccessStatusCode();
            response.StatusCode.GetType();

        }



    }
}
