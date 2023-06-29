using System.Collections.Generic;
using OnlineVoting.Models;

public interface IVoteRepository
{
    IEnumerable<Vote> GetAllVotes();
    void AddVote(Vote vote);
}
