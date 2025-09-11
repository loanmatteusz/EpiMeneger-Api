using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class UpdateEpiUseCase
    {
        private readonly IEpiRepository _repository;

        public UpdateEpiUseCase(IEpiRepository repository)
        {
            _repository = repository;
        }

        public async Task<Epi?> ExecuteAsync(Guid id, IUpdateEpiRequest request)
        {
            return await _repository.UpdateAsync(id, request);
        }
    }
}
