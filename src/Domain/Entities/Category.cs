using System.Text.Json.Serialization;

namespace EpiManager.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Epi> Epis { get; set; } = new List<Epi>();
    }
}
