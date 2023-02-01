using BugTracker_API.Models;
using BugTracker_API.Models.Dto;

namespace BugTracker_API.Data
{
    public class BugStore
    {
        public static List<BugDTO> bugList = new List<BugDTO>
        {
          new BugDTO {BugId = 1, Title = "BugTest1", Description = "BugTestDescription1", Status=Status.Open, DateCreated = DateOnly.FromDateTime(DateTime.Now), User = new UserDTO{UserId = 1, UserName = "TestUsername1"}},
          new BugDTO {BugId = 2, Title = "BugTest2", Description = "BugTestDescription2", Status=Status.Closed,DateCreated = DateOnly.FromDateTime(DateTime.Now), User = new UserDTO { UserId = 2, UserName = "TestUsername2" } }
        };
    }
}
