using System.ComponentModel.DataAnnotations;

namespace BugTracker_Web.Models.Dto
{
    public class BugCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserDTO? User { get; set; }
        public int UserId { get; set; }
    }
}
