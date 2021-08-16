using Api.Tests.MoqProviders;
using Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class dCandidateApiTests : IClassFixture<TestClientProvider>
    {
        private readonly HttpClient _client;
        public dCandidateApiTests(TestClientProvider provider)
        {
            _client = provider.client;
        }

        [Fact]
        public async Task GetAllCandidates_Test()
        {
            HttpResponseMessage response = await _client.GetAsync("http://localhost:5000/DCandidate/GetAllCandidates");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        //[InlineData(3)]
        public async Task GetCandidatesById_Test(int id)
        {
            var responseMessage = await _client.GetAsync($"http://localhost:5000/DCandidate/GetCandidateById?candidateId={id}");
            var response = JsonSerializer.Deserialize<dCandidate>(await responseMessage.Content.ReadAsStringAsync());
            Assert.Equal(id, response.CandidateId);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1001)]
        [InlineData(1002)]
        public async Task AddCandidates_Test(int candidateId)
        {
            var req = dCandidateProvider.GetRequestForAddCandidate(candidateId);
            var response = await _client.PutAsync("http://localhost:5000/DCandidate/AddCandidate", new StringContent(JsonSerializer.Serialize(req), System.Text.Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Equal($"{candidateId}", responseContent);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1001)]
        [InlineData(1002)]
        public async Task UpdateCandidate_Test(int candidateId)
        {
            var req = dCandidateProvider.GetRequestForUpdateCandidate(candidateId);
            var response = await _client.PutAsync("http://localhost:5000/DCandidate/UpdateCandidate", new StringContent(JsonSerializer.Serialize(req), System.Text.Encoding.UTF8, "application/json"));
            //var responseContent = JsonConvert.DeserializeObject<ReplaceOneResult>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(1001)]
        [InlineData(1002)]
        public async Task DeleteCandidates_Test(int candidateId)
        {
            var response = await _client.DeleteAsync($"http://localhost:5000/DCandidate/DeleteCandidateById?candidateId={candidateId}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(Convert.ToBoolean(responseContent));
        }
    }
}
