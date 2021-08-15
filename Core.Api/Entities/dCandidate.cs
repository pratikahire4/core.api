using Entities.Constants.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities
{
    [BsonIgnoreExtraElements]
    public class dCandidate
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("bloodGroup")]
        public BloodGroups BloodGroup { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("candidateId")]
        public int CandidateId { get; set; }
    }
}
