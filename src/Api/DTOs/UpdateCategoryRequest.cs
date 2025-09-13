using EpiManager.Application.Contracts;

namespace EpiManager.Api.DTOs
{
    public record UpdateCategoryRequest(
        string Name
    ) : IUpdateCategoryRequest;
}
