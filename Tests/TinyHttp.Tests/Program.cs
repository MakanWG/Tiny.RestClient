﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Tiny.Http.ForTest.Api;

namespace Tiny.Http.Tests
{
    [TestClass]
    public static class Program
    {
        private static TestServer _server;

        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            _server = new TestServer(new WebHostBuilder().
                UseUrls("http://localhost:4242").
                UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            _server?.Dispose();
        }

        public static HttpClient Client { get; set; }
    }
}
