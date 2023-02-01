using System.ComponentModel.DataAnnotations;

namespace BugTracker_API.Models.Dto
{
    public class BugDTO
    {
        public int BugId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public UserDTO User { get; set; }
    }
}
