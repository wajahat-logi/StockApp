using Microsoft.EntityFrameworkCore;
using StockApp.Trade.Core.Entity;

namespace StockApp.Trade.Core.Persistance.Context
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) { 
        }
        public DbSet<User> user { get; set; }
        public DbSet<StockApp.Trade.Core.Entity.Trade> trade { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Email);
        }
    }
}
