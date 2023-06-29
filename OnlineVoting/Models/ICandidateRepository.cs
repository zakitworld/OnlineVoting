namespace OnlineVoting.Models
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetAllCandidates();
        void AddCandidate(Candidate candidate);
        // Other repository methods

        Candidate GetCandidateById(int id);
        void RemoveCandidate(Candidate candidate);
        void SaveChanges();
    }

}
