using Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class dCandidateApiTests
    {
        [Fact]
        public async Task GetAllCandidates_Test()
        {
            var client = new TestClientProvider().client;

            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/api/DCandidate/GetAllCandidates");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetCandidatesById_Test(int id)
        {
            var client = new TestClientProvider().client;

            var responseMessage = await client.PutAsync("http://localhost:5000/api/DCandidate/GetCandidateById", new StringContent(id.ToString(), Encoding.UTF32, "application/json"));

            var response = JsonConvert.DeserializeObject<dCandidate>(await responseMessage.Content.ReadAsStringAsync());

            //Assert.Equal(id, response.CandidateId);
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }
    }
}
