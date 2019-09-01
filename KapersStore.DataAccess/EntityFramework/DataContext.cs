using KapersStore.Domain.CartManagement;
using KapersStore.Domain.KaperManagement;
using KapersStore.Domain.PurchaseManagement;
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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartSubscription> CartSubscriptions{ get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseSubscription> PurchaseSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUser();
            modelBuilder.BuildKaper();
            modelBuilder.BuildSubscription();
            modelBuilder.BuildComment();
            modelBuilder.BuildCart();
            modelBuilder.BuildCartSubscription();
            modelBuilder.BuildPurchase();
            modelBuilder.BuildPurchaseSubscription();

            base.OnModelCreating(modelBuilder);
        }
    }
}
