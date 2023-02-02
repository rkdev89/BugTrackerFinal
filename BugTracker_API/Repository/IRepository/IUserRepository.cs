using BugTracker_API.Models;
using System.Linq.Expressions;

namespace BugTracker_API.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateAsync(User entity);

    }
}
