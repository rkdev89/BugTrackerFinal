using BugTracker_API.Models;
using System.Linq.Expressions;

namespace BugTracker_API.Repository.IRepository
{
    public interface IBugRepository
    {
        Task<List<Bug>> GetAllAsync(Expression<Func<Bug, bool>> filter = null);
        Task<Bug> GetAsync(Expression<Func<Bug, bool>> filter = null);
        Task CreateAsync(Bug entity);
        Task RemoveAsync(Bug entity);
        Task SaveAsync();
        Task UpdateAsync(Bug entity);
    }
}
