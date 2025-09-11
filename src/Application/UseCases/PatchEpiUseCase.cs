using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class PatchEpiUseCase
    {
        private readonly IEpiRepository _repository;

        public PatchEpiUseCase(IEpiRepository repository)
        {
            _repository = repository;
        }

        public async Task<Epi?> ExecuteAsync(Guid id, IPatchEpiRequest request)
        {
            return await _repository.PatchAsync(id, request);
        }
    }
}
