using System.ComponentModel.DataAnnotations;
using EpiManager.Application.Contracts;

public class CreateEpiRequest : ICreateEpiRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "O CA deve ser maior que 0.")]
    public int CA { get; set; }

    [Required(ErrorMessage = "A data de validade é obrigatória.")]
    public DateTime Expiration { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    public Guid CategoryId { get; set; }

    public string? Description { get; set; }
}
