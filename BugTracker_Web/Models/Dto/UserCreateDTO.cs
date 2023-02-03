using System.ComponentModel.DataAnnotations;

namespace BugTracker_Web.Models.Dto
{
    public class UserCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        //public ICollection<BugDTO> Bugs { get; set; }
    }
}
