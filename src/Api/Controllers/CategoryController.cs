using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly CreateCategoryUseCase _createCategoryUseCase;
    // private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListCategoriesUseCase _listCategoriesUseCase;

    public CategoryController(
        CreateCategoryUseCase createCategoryUseCase,
        // GetEpiByIdUseCase getEpiByIdUseCase,
        ListCategoriesUseCase listCategoriesUseCase
    )
    {
        _createCategoryUseCase = createCategoryUseCase;
        _listCategoriesUseCase = listCategoriesUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var category = await _createCategoryUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id = category.Id }, category);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById(Guid id)
    // {
    //     var epi = await _getEpiByIdUseCase.ExecuteAsync(id);
    //     if (epi == null) return NotFound();
    //     return Ok(epi);
    // }

    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? name = null
    )
    {
        var result = await _listCategoriesUseCase.ExecuteAsync(page, pageSize, name);
        return Ok(result);
    }
}
