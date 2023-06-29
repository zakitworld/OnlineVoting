using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OnlineVoting.Models;

public class ElectionController : Controller
{
    private readonly IElectionRepository _electionRepository;

    public ElectionController(IElectionRepository electionRepository)
    {
        _electionRepository = electionRepository;
    }

    public IActionResult Index()
    {
        var elections = _electionRepository.GetAllElections();
        return View(elections);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Election election)
    {
        if (ModelState.IsValid)
        {
            _electionRepository.AddElection(election);
            return RedirectToAction(nameof(Index));
        }
        return View(election);
    }

    public IActionResult Edit(int id)
    {
        var election = _electionRepository.GetElectionById(id);
        if (election == null)
        {
            return NotFound();
        }
        return View(election);
    }

    [HttpPost]
    public IActionResult Edit(Election election)
    {
        if (ModelState.IsValid)
        {
            _electionRepository.UpdateElection(election);
            return RedirectToAction(nameof(Index));
        }
        return View(election);
    }
}
