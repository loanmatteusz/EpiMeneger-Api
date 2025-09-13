using EpiManager.Application.Interfaces;

namespace EpiManager.Application.UseCases
{
    public class DeleteCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
