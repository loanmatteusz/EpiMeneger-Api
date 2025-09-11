using System.ComponentModel.DataAnnotations;
using EpiManager.Application.Contracts;

public class CreateCategoryRequest : ICreateCategoryRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    public string Name { get; set; } = string.Empty;
}
