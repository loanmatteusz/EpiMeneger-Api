using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class CreateEpiUseCase
    {
        private readonly IEpiRepository _repository;
        private readonly IGuidGenerator _guidGenerator;

        public CreateEpiUseCase(IEpiRepository repository, IGuidGenerator guidGenerator)
        {
            _repository = repository;
            _guidGenerator = guidGenerator;
        }

        public async Task<Epi> ExecuteAsync(ICreateEpiRequest request)
        {
            var epi = new Epi
            {
                Id = _guidGenerator.Generate(),
                Name = request.Name,
                CA = request.CA,
                Expiration = request.Expiration.ToUniversalTime(),
                Category = request.Category,
                Description = request.Description
            };

            await _repository.AddAsync(epi);
            return epi;
        }
    }
}
