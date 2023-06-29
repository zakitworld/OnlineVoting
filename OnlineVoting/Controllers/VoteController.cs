using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineVoting.Models;
using System.Linq;
using OnlineVoting.Models;

public class VoteController : Controller
{
    private readonly IVoteRepository _voteRepository;
    private readonly ICandidateRepository _candidateRepository;

    public VoteController(IVoteRepository voteRepository, ICandidateRepository candidateRepository)
    {
        _voteRepository = voteRepository;
        _candidateRepository = candidateRepository;
    }

    public IActionResult Index()
    {
        var votes = _voteRepository.GetAllVotes();
        return View(votes);
        /*var candidates = _candidateRepository.GetAllCandidates();
        var viewModel = new VoteViewModel
        {
            Candidates = (SelectList)candidates
        };
        return View(viewModel);*/
    }

    public IActionResult Create()
    {
        var candidates = _candidateRepository.GetAllCandidates();
        var viewModel = new VoteViewModel
        {
            Candidates = new SelectList(candidates, "Id", "Name")
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(VoteViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var vote = new Vote
            {
                CandidateId = viewModel.CandidateId,
                // Other vote properties
            };
            _voteRepository.AddVote(vote);
            return RedirectToAction(nameof(Index));
        }

        viewModel.Candidates = new SelectList(_candidateRepository.GetAllCandidates(), "Id", "Name");
        return View(viewModel);
    }
}
