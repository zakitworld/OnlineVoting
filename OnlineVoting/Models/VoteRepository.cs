using System.Collections.Generic;
using OnlineVoting.Models;
using Microsoft.EntityFrameworkCore;

public class VoteRepository : IVoteRepository
{
    private readonly ApplicationDbContext _context;

    public VoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Vote> GetAllVotes()
    {
        return _context.Votes.ToList();
    }

    public void AddVote(Vote vote)
    {
        _context.Votes.Add(vote);
        _context.SaveChanges();
    }
}
