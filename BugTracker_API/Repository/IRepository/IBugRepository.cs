using BugTracker_API.Models;
using System.Linq.Expressions;

namespace BugTracker_API.Repository.IRepository
{
    public interface IBugRepository : IRepository<Bug>
    {
        Task<Bug> UpdateAsync(Bug entity);
    }
}
