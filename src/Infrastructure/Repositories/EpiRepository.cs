using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EpiManager.Infrastructure.Repositories
{
    public class EpiRepository : IEpiRepository
    {
        private readonly EpiDbContext _context;

        public EpiRepository(EpiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Epi epi)
        {
            _context.Epis.Add(epi);
            await _context.SaveChangesAsync();
        }

        public async Task<Epi?> GetByIdAsync(Guid id)
        {
            return await _context.Epis.FindAsync(id);
        }

        public async Task<IEnumerable<Epi>> GetAllAsync()
        {
            return await _context.Epis.ToListAsync();
        }
    }
}
