using Entities;

namespace Api.Tests.MoqProviders
{
    public static class dCandidateProvider
    {
        public static dCandidate GetRequestForAddCandidate(int candidateId)
        {
            return new dCandidate()
            {
                CandidateId = candidateId,
                FirstName="Test_F",
                LastName="Test_L",
                Age=140,
                BloodGroup = Entities.Constants.Enums.BloodGroups.BPositive,
                Address="New Pyongyang",
            };
        }

        public static dCandidate GetRequestForUpdateCandidate(int candidateId)
        {
            return new dCandidate()
            {
                CandidateId = candidateId,
                FirstName = "Test_F",
                LastName = "Test_L",
                Age = 140,
                BloodGroup = Entities.Constants.Enums.BloodGroups.BPositive,
                Address = "New Delhi",
            };
        }
    }
}
