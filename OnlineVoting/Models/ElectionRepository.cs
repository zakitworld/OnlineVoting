using System.Collections.Generic;
using System.Linq;
using OnlineVoting.Models;

public class ElectionRepository : IElectionRepository
{
    private readonly ApplicationDbContext _context;

    public ElectionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Election> GetAllElections()
    {
        return _context.Elections.ToList();
    }

    public Election GetElectionById(int id)
    {
        return _context.Elections.Find(id);
    }

    public void AddElection(Election election)
    {
        _context.Elections.Add(election);
        _context.SaveChanges();
    }

    public void UpdateElection(Election election)
    {
        _context.Elections.Update(election);
        _context.SaveChanges();
    }
}
