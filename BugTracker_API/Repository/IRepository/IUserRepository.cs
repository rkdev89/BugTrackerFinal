using BugTracker_API.Models;
using System.Linq.Expressions;

namespace BugTracker_API.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<User> GetAsync(Expression<Func<User, bool>> filter = null);
        Task CreateAsync(User entity);
        Task RemoveAsync(User entity);
        Task UpdateAsync(User entity);
        Task SaveAsync();
    }
}
