using System.Collections.Generic;
using OnlineVoting.Models;

public interface IElectionRepository
{
    IEnumerable<Election> GetAllElections();
    Election GetElectionById(int id);
    void AddElection(Election election);
    void UpdateElection(Election election);
}
