using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        AccountType = AccountType.Standard
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Tom",
                        LastName = "Ford",
                        Email = "tom.ford@example.com",
                        DateOfBirth = new DateTime(1995, 2, 2, 0, 0, 0, DateTimeKind.Utc),
                        AccountType = AccountType.Free
                    }
            );
        }
    }
}
