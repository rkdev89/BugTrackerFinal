using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BugTracker_API.Repository
{
    public class BugRepository : IBugRepository
    {
        private readonly ApplicationDbContext _db;
        public BugRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Bug entity)
        {
            await _db.Bugs.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Bug> GetAsync(Expression<Func<Bug, bool>> filter = null)
        {
            IQueryable<Bug> query = _db.Bugs;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Bug>> GetAllAsync(Expression<Func<Bug, bool>> filter = null)
        {
            IQueryable<Bug> query = _db.Bugs;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Bug entity)
        {
            _db.Bugs.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bug entity)
        {
            _db.Bugs.Update(entity);
            await SaveAsync();
        }
    }
}
