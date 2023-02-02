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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user1 = new User()
            {
                Id = 1,
                UserName = "TestUsername1"
            };

            modelBuilder.Entity<User>().HasData(user1);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 1,
                    Title = "TestTitle1",
                    Description = "TestDescription1",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 1,
                });

            var user2 = new User()
            {
                Id = 2,
                UserName = "TestUsername2"
            };

            modelBuilder.Entity<User>().HasData(user2);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 2,
                    Title = "TestTitle2",
                    Description = "TestDescription2",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 2,
                });

            var user3 = new User()
            {
                Id = 3,
                UserName = "TestUsername3"
            };

            modelBuilder.Entity<User>().HasData(user3);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 3,
                    Title = "TestTitle3",
                    Description = "TestDescription3",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 3,
                });

            var user4 = new User()
            {
                Id = 4,
                UserName = "TestUsername4"
            };

            modelBuilder.Entity<User>().HasData(user4);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 4,
                    Title = "TestTitle4",
                    Description = "TestDescription4",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 4,
                });

            var user5 = new User()
            {
                Id = 5,
                UserName = "TestUsername5"
            };

            modelBuilder.Entity<User>().HasData(user5);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 5,
                    Title = "TestTitle5",
                    Description = "TestDescription5",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 5,
                });

            var user6 = new User()
            {
                Id = 6,
                UserName = "TestUsername6"
            };

            modelBuilder.Entity<User>().HasData(user6);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 6,
                    Title = "TestTitle6",
                    Description = "TestDescription6",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 6,
                });

            var user7 = new User()
            {
                Id = 7,
                UserName = "TestUsername7"
            };

            modelBuilder.Entity<User>().HasData(user7);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 7,
                    Title = "TestTitle7",
                    Description = "TestDescription7",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 7,
                });

            var user8 = new User()
            {
                Id = 8,
                UserName = "TestUsername8"
            };

            modelBuilder.Entity<User>().HasData(user8);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 8,
                    Title = "TestTitle8",
                    Description = "TestDescription8",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 8,
                });

            var user9 = new User()
            {
                Id = 9,
                UserName = "TestUsername9"
            };

            modelBuilder.Entity<User>().HasData(user9);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 9,
                    Title = "TestTitle9",
                    Description = "TestDescription9",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 9,
                });

            var user10 = new User()
            {
                Id = 10,
                UserName = "TestUsername10"
            };

            modelBuilder.Entity<User>().HasData(user10);

            modelBuilder.Entity<Bug>().HasData(
                new Bug()
                {
                    Id = 10,
                    Title = "TestTitle10",
                    Description = "TestDescription10",
                    DateCreated = DateTime.Now,
                    Status = Status.Open,
                    UserId = 10,
                });

            //modelBuilder.Entity<User>().HasData(
            //    new User()
            //    {
            //        UserId= 1,
            //        UserName="TestUsername1",
            //        Bugs= new List<Bug>() { new Bug {BugId=1,Title="TestTitle1", Description="TestDescription1", DateCreated= Da } }
            //    });



            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Bugs)
            //    .WithOne(x => x.User);

            //modelBuilder.Entity<Bug>().HasData(
            //    new User()
            //    {
            //        UserId = 1,
            //        UserName = "TestUser1"
            //    });

            //modelBuilder.Entity<Bug>().HasData(
            //    new Bug()
            //    {
            //        BugId = 1,
            //        Title = "TestTitle1",
            //        Description = "Test1Description1",
            //        DateCreated = DateTime.Now,
            //        Status = Status.Closed,
            //        UserId = 1,
            //    });


            //modelBuilder.Entity<User>().HasData(
            //    new User { UserId = 1, UserName = "TestUser1" },
            //    new User { UserId = 2, UserName = "TestUser2" },
            //    new User { UserId = 3, UserName = "TestUser3" },
            //    new User { UserId = 4, UserName = "TestUser4" },
            //    new User { UserId = 5, UserName = "TestUser5" },
            //    new User { UserId = 6, UserName = "TestUser6" },
            //    new User { UserId = 7, UserName = "TestUser7" },
            //    new User { UserId = 8, UserName = "TestUser8" },
            //    new User { UserId = 9, UserName = "TestUser9" },
            //    new User { UserId = 10, UserName = "TestUser10" }
            //    );


            //modelBuilder.Entity<Bug>().HasData(
            //    new Bug { BugId = 1, Title = "TestTitle1", Description = "Test Description1", DateCreated = DateTime.Now, Status = Status.Open, User=new User { UserId=1,UserName="TestUsername1"} },
            //    new Bug { BugId = 2, Title = "TestTitle2", Description = "Test Description2", DateCreated = DateTime.Now, Status = Status.Closed, User = new User { UserId = 2, UserName = "TestUsername2" } },
            //    new Bug { BugId = 3, Title = "TestTitle3", Description = "Test Description3", DateCreated = DateTime.Now, Status = Status.Open, User = new User { UserId = 3, UserName = "TestUsername3" } },
            //    new Bug { BugId = 4, Title = "TestTitle4", Description = "Test Description4", DateCreated = DateTime.Now, Status = Status.Closed, User = new User { UserId = 4, UserName = "TestUsername4" } },
            //    new Bug { BugId = 5, Title = "TestTitle5", Description = "Test Description5", DateCreated = DateTime.Now, Status = Status.Open, User = new User { UserId = 5, UserName = "TestUsername5" } },
            //    new Bug { BugId = 6, Title = "TestTitle6", Description = "Test Description6", DateCreated = DateTime.Now, Status = Status.Closed, User = new User { UserId = 6, UserName = "TestUsername6" } },
            //    new Bug { BugId = 7, Title = "TestTitle7", Description = "Test Description7", DateCreated = DateTime.Now, Status = Status.Open, User = new User { UserId = 7, UserName = "TestUsername7" } },
            //    new Bug { BugId = 8, Title = "TestTitle8", Description = "Test Description8", DateCreated = DateTime.Now, Status = Status.Closed, User = new User { UserId = 8, UserName = "TestUsername8" } },
            //    new Bug { BugId = 9, Title = "TestTitle9", Description = "Test Description9", DateCreated = DateTime.Now, Status = Status.Open, User = new User { UserId = 9, UserName = "TestUsername9" } },
            //    new Bug { BugId = 10, Title = "TestTitle10", Description = "Test Description10", DateCreated = DateTime.Now, Status = Status.Closed, User = new User { UserId = 10, UserName = "TestUsername10" } }
            //    );
        }
    }
}
