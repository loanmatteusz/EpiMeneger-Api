namespace EpiManager.Application.Contracts
{
    public interface IUpdateEpiRequest
    {
        string Name { get; }
        int CA { get; }
        DateTime Expiration { get; }
        Guid CategoryId { get; }
        string? Description { get; }
    }
}
