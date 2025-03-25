using Untouchable.Horse.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Untouchable.Horse.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    { }

    public DbSet<Item> Items { get; set; }
    }
}