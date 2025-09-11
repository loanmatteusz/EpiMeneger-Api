using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EpiManager.Application.Contracts;

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

        public async Task<Epi?> UpdateAsync(Guid id, IUpdateEpiRequest epi)
        {
            var existing = await _context.Epis.FindAsync(id);
            if (existing == null) return null;

            existing.Name = epi.Name;
            existing.CA = epi.CA;
            existing.Expiration = epi.Expiration;
            existing.Category = epi.Category;
            existing.Description = epi.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Epi?> PatchAsync(Guid id, IPatchEpiRequest request)
        {
            var existing = await _context.Epis.FindAsync(id);
            if (existing == null) return null;

            if (request.Name is not null) existing.Name = request.Name;
            if (request.CA.HasValue) existing.CA = request.CA.Value;
            if (request.Expiration.HasValue) existing.Expiration = request.Expiration.Value;
            if (request.Category is not null) existing.Category = request.Category;
            if (request.Description is not null) existing.Description = request.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var epi = await _context.Epis.FindAsync(id);
            if (epi == null) return false;
            _context.Epis.Remove(epi);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
