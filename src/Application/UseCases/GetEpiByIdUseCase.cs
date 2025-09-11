using EpiManager.Application.Interfaces;
using EpiManager.Domain.Entities;

namespace EpiManager.Application.UseCases
{
    public class GetEpiByIdUseCase
    {
        private readonly IEpiRepository _repository;

        public GetEpiByIdUseCase(IEpiRepository repository)
        {
            _repository = repository;
        }

        public async Task<Epi?> ExecuteAsync(Guid id)
        {
            var epi = await _repository.GetByIdAsync(id);
            return epi;
        }
    }
}
