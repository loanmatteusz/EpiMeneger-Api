using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class UpdateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category?> ExecuteAsync(Guid id, IUpdateCategoryRequest request)
        {
            return await _repository.UpdateAsync(id, request);
        }
    }
}
