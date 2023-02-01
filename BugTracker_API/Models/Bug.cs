namespace BugTracker_API.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
    }
}
