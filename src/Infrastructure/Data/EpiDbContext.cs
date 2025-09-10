using Microsoft.EntityFrameworkCore;
using EpiManager.Domain.Entities;

namespace EpiManager.Infrastructure.Data
{
    public class EpiDbContext : DbContext
    {
        public EpiDbContext(DbContextOptions<EpiDbContext> options)
            : base(options) { }

        public DbSet<Epi> Epis { get; set; }
    }
}
