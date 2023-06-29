using OnlineVoting.Models;
using System.Collections.Generic;
using System.Linq;

public class CandidateRepository : ICandidateRepository
{
    private readonly ApplicationDbContext _context;

    public CandidateRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Candidate> GetAllCandidates()
    {
        return _context.Candidates.ToList();
    }

    public void AddCandidate(Candidate candidate)
    {
        _context.Candidates.Add(candidate);
        _context.SaveChanges();
    }

    // Other repository methods implementation

    public Candidate GetCandidateById(int id)
    {
        return _context.Candidates.FirstOrDefault(c => c.Id == id);
    }
    public void RemoveCandidate(Candidate candidate)
    {
        _context.Candidates.Remove(candidate);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
