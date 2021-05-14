using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CryptoCoin.SolutionCore.Tests.Fixtures
{
    [TestClass]
    public class TesteContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TesteContext()
        {
            SetupCliente();
        }

        private void SetupCliente()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = _server.CreateClient();
        }
    }
}
