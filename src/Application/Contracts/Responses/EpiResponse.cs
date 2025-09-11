public class EpiResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int CA { get; set; }
    public DateTime Expiration { get; set; }
    public Guid CategoryId { get; set; }
    public string Category { get; set; } = null!;
    public string? Description { get; set; }
}
