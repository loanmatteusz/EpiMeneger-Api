using EpiManager.Application.Interfaces;
using Medo;

namespace EpiManager.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Generate()
        {
            return Uuid7.NewUuid7();
        }
    }
}
