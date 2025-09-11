using Microsoft.EntityFrameworkCore;
using EpiManager.Domain.Entities;

namespace EpiManager.Infrastructure.Data
{
    public class EpiDbContext : DbContext
    {
        public EpiDbContext(DbContextOptions<EpiDbContext> options)
            : base(options) { }

        public DbSet<Epi> Epis { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Epi>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Epis)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
