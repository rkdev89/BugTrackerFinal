using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BugTracker_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = _db.Users;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = _db.Users;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(User entity)
        {
            _db.Users.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _db.Users.Update(entity);
            await SaveAsync();
        }
    }
}
