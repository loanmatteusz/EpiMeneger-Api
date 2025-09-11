using EpiManager.Application.Contracts;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category?> GetByIdAsync(Guid id);
        Task<PagedResult<Category>> ListAsync(int page, int pageSize, string? name);
        Task<Category?> UpdateAsync(Guid id, IUpdateCategoryRequest category);
        Task<bool> DeleteAsync(Guid id);
    }
}
