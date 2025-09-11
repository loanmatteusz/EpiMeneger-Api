using EpiManager.Application.Contracts;
using System.ComponentModel.DataAnnotations;

namespace EpiManager.Api.DTOs
{
    public record UpdateEpiRequest(
        string Name,
        [Range(1, int.MaxValue)] int CA,
        DateTime Expiration,
        Guid CategoryId,
        string? Description
    ) : IUpdateEpiRequest;
}
