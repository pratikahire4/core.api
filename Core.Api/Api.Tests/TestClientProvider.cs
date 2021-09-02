using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Api.Tests
{
    public class TestClientProvider : IDisposable
    {
        public HttpClient client;

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartUpTest>());
            client = server.CreateClient();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}