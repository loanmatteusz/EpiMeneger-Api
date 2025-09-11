namespace EpiManager.Application.DTOs
{
    public class EpiMetricsResponse
    {
        public int Total { get; set; }
        public int Expired { get; set; }
        public Dictionary<string, int> ByCategory { get; set; } = new();
    }
}
