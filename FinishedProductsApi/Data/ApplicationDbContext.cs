using FinishedProductsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinishedProductsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FinishedProduct> FinishedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the entity to map to the new view
            modelBuilder.Entity<FinishedProduct>()
                .ToView("v_sFinishedProductsAPI")
                .HasKey(e => e.Id);
        }
    }
}