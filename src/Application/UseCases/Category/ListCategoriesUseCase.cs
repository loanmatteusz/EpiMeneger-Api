using EpiManager.Application.Contracts;
using EpiManager.Application.Interfaces;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.UseCases
{
    public class ListCategoriesUseCase
    {
        private readonly ICategoryRepository _repository;

        public ListCategoriesUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Category>> ExecuteAsync(
            int page,
            int pageSize,
            string? name
        )
        {
            return await _repository.ListAsync(page, pageSize, name);
        }
    }
}
