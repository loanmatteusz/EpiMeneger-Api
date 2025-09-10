namespace EpiManager.Api.DTOs
{
    public record EpiRequest(string Name, int CA, DateTime Expiration, string Category, string? Description);
}
