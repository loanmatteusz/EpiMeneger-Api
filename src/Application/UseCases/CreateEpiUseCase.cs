using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;

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

        public async Task<Epi> ExecuteAsync(string name, int ca, DateTime expiration, string category, string? description = null)
        {
            var epi = new Epi
            {
                Id = _guidGenerator.Generate(),
                Name = name,
                CA = ca,
                Expiration = expiration.ToUniversalTime(),
                Category = category,
                Description = description
            };

            await _repository.AddAsync(epi);
            return epi;
        }
    }
}
