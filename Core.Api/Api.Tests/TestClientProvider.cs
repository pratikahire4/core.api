using Api;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Api.Tests
{
    public class TestClientProvider
    {
        public HttpClient client;

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartUpTest>());
            client = server.CreateClient();
        }
    }
}