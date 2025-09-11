namespace EpiManager.Application.Contracts
{
    public interface ICreateEpiRequest
    {
        string Name { get; }
        int CA { get; }
        DateTime Expiration { get; }
        Guid CategoryId { get; }
        string? Description { get; }
    }
}
