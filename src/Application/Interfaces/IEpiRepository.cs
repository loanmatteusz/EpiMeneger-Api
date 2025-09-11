using EpiManager.Application.Contracts;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.Interfaces
{
    public interface IEpiRepository
    {
        Task AddAsync(Epi epi);
        Task<Epi?> GetByIdAsync(Guid id);
        Task<PagedResult<Epi>> ListAsync(int page, int pageSize, string? name, int? ca, string? category);
        Task<Epi?> UpdateAsync(Guid id, IUpdateEpiRequest epi);
        Task<Epi?> PatchAsync(Guid id, IPatchEpiRequest epi);
        Task<bool> DeleteAsync(Guid id);
    }
}
