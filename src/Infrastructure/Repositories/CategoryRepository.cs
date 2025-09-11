using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EpiManager.Application.Contracts;

namespace EpiManager.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EpiDbContext _context;

        public CategoryRepository(EpiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<PagedResult<Category>> ListAsync(int page, int pageSize, string? name)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Category>
            {
                Data = items,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<Category?> UpdateAsync(Guid id, IUpdateCategoryRequest category)
        {
            var existing = await _context.Categories.FindAsync(id);
            if (existing == null) return null;

            existing.Name = category.Name;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
