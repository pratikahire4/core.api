using Entities;

namespace Api.Tests.MoqProviders
{
    internal static class dCandidateProvider
    {
        internal static dCandidate GetRequestForAddCandidate(int candidateId)
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

        internal static dCandidate GetRequestForUpdateCandidate(int candidateId)
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
