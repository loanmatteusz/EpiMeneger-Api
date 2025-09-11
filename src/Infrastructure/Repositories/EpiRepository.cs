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

        public async Task<PagedResult<Epi>> ListAsync(int page, int pageSize, string? name, int? ca, string? category)
        {
            var query = _context.Epis.Include(e => e.Category).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            if (ca.HasValue)
                query = query.Where(e => e.CA == ca.Value);

            if (!string.IsNullOrEmpty(category))
                query = query.Where(e => EF.Functions.ILike(e.Category.Name, $"%{category}%"));

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Epi>
            {
                Data = items,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<Epi?> UpdateAsync(Guid id, IUpdateEpiRequest epi)
        {
            var existing = await _context.Epis.FindAsync(id);
            if (existing == null) return null;

            existing.Name = epi.Name;
            existing.CA = epi.CA;
            existing.Expiration = epi.Expiration;
            existing.CategoryId = epi.CategoryId;
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
            if (request.CategoryId is not null) existing.CategoryId = request.CategoryId.Value;
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

        public async Task<int> CountAsync()
        {
            return await _context.Epis.CountAsync();
        }

        public async Task<Dictionary<string, int>> CountByCategoryAsync()
        {
            return await _context.Epis
                .Include(e => e.Category)
                .GroupBy(e => e.Category!.Name)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Category, x => x.Count);
        }

        public async Task<int> CountExpiringSoonAsync(int days)
        {
            var now = DateTime.UtcNow;
            var targetDate = now.AddDays(days);
            return await _context.Epis
                .CountAsync(e => e.Expiration >= now && e.Expiration <= targetDate);
        }
    }
}
