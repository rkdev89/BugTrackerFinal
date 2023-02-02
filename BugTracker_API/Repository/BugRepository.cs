using BugTracker_API.Data;
using BugTracker_API.Models;
using BugTracker_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BugTracker_API.Repository
{
    public class BugRepository :Repository<Bug>, IBugRepository
    {
        private readonly ApplicationDbContext _db;
        public BugRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Bug> UpdateAsync(Bug entity)
        {
            _db.Bugs.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
