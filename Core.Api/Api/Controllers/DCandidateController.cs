using Entities;
using Entities.Constants;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DCandidateController : Controller
    {
        [HttpGet]
        public IEnumerable<dCandidate> GetAllDetails ()
        {
            MongoClient client = new MongoClient();

            var list = client.ListDatabases().ToList();

            IMongoDatabase database = client.GetDatabase(MongoConstants.dbName);
            IMongoCollection<dCandidate> collection = database.GetCollection<dCandidate>(MongoConstants.dCandidateColletion);

            //var a = collection.Find(x => x.Age == 26);

            return null;
            return collection.Find(x => x.Age == 26).ToList();
        }
    }
}
