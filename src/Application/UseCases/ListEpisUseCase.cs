using EpiManager.Application.Contracts;
using EpiManager.Application.Interfaces;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.UseCases
{
    public class ListEpisUseCase
    {
        private readonly IEpiRepository _repository;

        public ListEpisUseCase(IEpiRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Epi>> ExecuteAsync(
            int page,
            int pageSize,
            string? name,
            int? ca,
            string? category
        )
        {
            return await _repository.ListAsync(page, pageSize, name, ca, category);
        }
    }
}
