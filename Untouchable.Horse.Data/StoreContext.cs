using Untouchable.Horse.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Untouchable.Horse.Domain.Orders;

namespace Untouchable.Horse.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}
