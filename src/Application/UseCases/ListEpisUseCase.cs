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

        public async Task<IEnumerable<Epi>> ExecuteAsync()
        {
            var epis = await _repository.GetAllAsync();
            return epis;
        }
    }
}
