using EpiManager.Domain.Entities;
using EpiManager.Application.Interfaces;
using EpiManager.Application.Contracts;

namespace EpiManager.Application.UseCases
{
    public class CreateEpiUseCase
    {
        private readonly IEpiRepository _epiRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGuidGenerator _guidGenerator;

        public CreateEpiUseCase(IEpiRepository epiRepository, ICategoryRepository categoryRepository, IGuidGenerator guidGenerator)
        {
            _categoryRepository = categoryRepository;
            _epiRepository = epiRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<EpiResponse> ExecuteAsync(ICreateEpiRequest request)
        {
            var epi = new Epi
            {
                Id = _guidGenerator.Generate(),
                Name = request.Name,
                CA = request.CA,
                Expiration = request.Expiration.ToUniversalTime(),
                CategoryId = request.CategoryId,
                Description = request.Description
            };

            await _epiRepository.AddAsync(epi);

            var category = await _categoryRepository.GetByIdAsync(epi.CategoryId);

            return new EpiResponse
            {
                Id = epi.Id,
                Name = epi.Name,
                CA = epi.CA,
                Expiration = epi.Expiration,
                CategoryId = epi.CategoryId,
                Category = category?.Name ?? string.Empty,
                Description = epi.Description
            };
        }
    }
}
