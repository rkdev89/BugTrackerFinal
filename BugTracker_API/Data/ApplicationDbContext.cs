using BugTracker_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
