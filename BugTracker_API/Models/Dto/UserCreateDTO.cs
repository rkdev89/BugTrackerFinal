using System.ComponentModel.DataAnnotations;

namespace BugTracker_API.Models.Dto
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        //public ICollection<Bug> Bugs { get; set; }
    }
}
