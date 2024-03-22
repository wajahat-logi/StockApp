using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTToken.Model
{
    public class ApplicationDBContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name= "Admin", ConcurrencyStamp= "1", NormalizedName= "Admin" },
                new IdentityRole() { Name= "User", ConcurrencyStamp= "2", NormalizedName= "User" },
                new IdentityRole() { Name= "HR", ConcurrencyStamp= "3", NormalizedName= "HR" }
            );
        }
    }
}
