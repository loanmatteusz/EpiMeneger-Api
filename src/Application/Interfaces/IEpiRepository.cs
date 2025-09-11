using EpiManager.Application.Contracts;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.Interfaces
{
    public interface IEpiRepository
    {
        Task AddAsync(Epi epi);
        Task<Epi?> GetByIdAsync(Guid id);
        Task<IEnumerable<Epi>> GetAllAsync();
        Task<Epi?> PatchAsync(Guid id, IPatchEpiRequest epi);
        Task<bool> DeleteAsync(Guid id);
    }
}
