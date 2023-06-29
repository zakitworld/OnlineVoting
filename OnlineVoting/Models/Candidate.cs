namespace OnlineVoting.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Party { get; set; }

        [Display(Name = "Profile Image")]
        public byte[] ProfileImage { get; set; }

        // Other properties and relationships
    }

}
