using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBACWebAPI.Models;

namespace RBACWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroupCategory> GroupCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PremiumUser> PremiumUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Add any extra relationships if needed
        }
    }



}
