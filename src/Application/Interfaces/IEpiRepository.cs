using EpiManager.Application.Contracts;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.Interfaces
{
    public interface IEpiRepository
    {
        Task AddAsync(Epi epi);
        Task<Epi?> GetByIdAsync(Guid id);
        Task<IEnumerable<Epi>> GetAllAsync();
        Task<Epi?> UpdateAsync(Guid id, IUpdateEpiRequest epi);
        Task<bool> DeleteAsync(Guid id);
    }
}
