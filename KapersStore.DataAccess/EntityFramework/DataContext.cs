using KapersStore.Domain.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace KapersStore.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUser();
        }
    }
}
