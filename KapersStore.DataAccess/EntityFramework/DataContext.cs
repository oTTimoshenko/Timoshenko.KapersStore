using KapersStore.Domain.KaperManagement;
using KapersStore.Domain.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace KapersStore.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Kaper> Kapers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUser();
            modelBuilder.BuildKaper();
            modelBuilder.BuildSubscription();
            modelBuilder.BuildComment();
            base.OnModelCreating(modelBuilder);
        }
    }
}
