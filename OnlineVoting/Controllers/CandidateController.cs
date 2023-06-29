using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using OnlineVoting.Models;

namespace OnlineVoting.Controllers
{

    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IActionResult Index()
        {
            var candidates = _candidateRepository.GetAllCandidates();
            return View(candidates);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Candidate candidate, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        candidate.ProfileImage = ms.ToArray();
                    }
                }
                else
                {
                    ModelState.AddModelError("ProfileImage", "The Profile Image field is required.");
                    return View(candidate);
                }

                _candidateRepository.AddCandidate(candidate);
                _candidateRepository.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(candidate);
        }


        public IActionResult Edit(int id)
        {
            var candidate = _candidateRepository.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        [HttpPost]
        public IActionResult Edit(int id, Candidate updatedCandidate)
        {
            var candidate = _candidateRepository.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                candidate.Name = updatedCandidate.Name;
                candidate.Party = updatedCandidate.Party;
                candidate.ProfileImage = updatedCandidate.ProfileImage;
                // Update other properties as needed

                _candidateRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updatedCandidate);
        }

        public IActionResult Details(int id)
        {
            var candidate = _candidateRepository.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        public IActionResult Delete(int id)
        {
            var candidate = _candidateRepository.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var candidate = _candidateRepository.GetCandidateById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            _candidateRepository.RemoveCandidate(candidate);
            _candidateRepository.SaveChanges();

            return RedirectToAction("Index");
        }
        // Other actions: Edit, Delete, Details, etc.
    }

}
