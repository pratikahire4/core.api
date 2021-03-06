using Entities;
using Entities.Constants;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    ///Candidates controller
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DCandidateController : Controller
    {
        private IMongoCollection<dCandidate> _candidateCollection;
        
        ///ctor
        public DCandidateController(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(MongoConstants.dbName);
            _candidateCollection = database.GetCollection<dCandidate>(MongoConstants.dCandidateColletion);
        }

        /// <summary>
        /// Fetches all candidates.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            try
            {
                return Ok(await _candidateCollection.Find(Builders<dCandidate>.Filter.Empty).ToListAsync());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Fetches candidate by it's id.
        /// </summary>
        [HttpPut]
        public IActionResult GetCandidateById([FromBody]int candidateId)
        {
            try
            {
                var candidates = _candidateCollection.Find(x => x.CandidateId == candidateId).Single();
                return Ok(candidates);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes specified candidate.
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteCandidateById([FromBody] int candidateId)
        {
            try
            {
                var candidates = _candidateCollection.DeleteOne(x => x.CandidateId == candidateId);
                return Ok(candidates.IsAcknowledged);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds new candidates.
        /// </summary>
        [HttpPut]
        public IActionResult AddCandidate([FromBody]dCandidate dCandidate)
        {
            try
            {
                _candidateCollection.InsertOne(dCandidate);
                return Created("Candidate added.", dCandidate.Id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
