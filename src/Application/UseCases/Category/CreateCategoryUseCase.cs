using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class CreateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;
        private readonly IGuidGenerator _guidGenerator;

        public CreateCategoryUseCase(ICategoryRepository repository, IGuidGenerator guidGenerator)
        {
            _repository = repository;
            _guidGenerator = guidGenerator;
        }

        public async Task<Category> ExecuteAsync(ICreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = _guidGenerator.Generate(),
                Name = request.Name,
            };

            await _repository.AddAsync(category);
            return category;
        }
    }
}
