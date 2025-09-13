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

    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? name = null
    )
    {
        if (page < 1)
        {
            page = 1;
        }
        if (pageSize < 1)
        {
            pageSize = 10;
        }
        var result = await _listCategoriesUseCase.ExecuteAsync(page, pageSize, name);
        return Ok(result);
    }
}
