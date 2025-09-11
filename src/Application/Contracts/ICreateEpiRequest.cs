namespace EpiManager.Application.Contracts
{
    public interface ICreateEpiRequest
    {
        string Name { get; }
        int CA { get; }
        DateTime Expiration { get; }
        string Category { get; }
        string? Description { get; }
    }
}
