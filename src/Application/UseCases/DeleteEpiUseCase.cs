using EpiManager.Application.Interfaces;

namespace EpiManager.Application.UseCases
{
    public class DeleteEpiUseCase
    {
        private readonly IEpiRepository _repository;

        public DeleteEpiUseCase(IEpiRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            var epi = await _repository.GetByIdAsync(id);
            if (epi == null) return false;
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
