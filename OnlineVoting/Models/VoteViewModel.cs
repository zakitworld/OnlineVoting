using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineVoting.Models;

namespace OnlineVoting.Models
{
    public class VoteViewModel
    {
        [Required(ErrorMessage = "Please select a candidate.")]
        public int CandidateId { get; set; }

        // Additional properties specific to your vote view

        public SelectList Candidates { get; set; }
    }
}
