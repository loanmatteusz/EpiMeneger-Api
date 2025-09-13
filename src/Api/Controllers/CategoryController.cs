using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;
using EpiManager.Api.DTOs;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly CreateCategoryUseCase _createCategoryUseCase;
    // private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListCategoriesUseCase _listCategoriesUseCase;
    private readonly UpdateCategoryUseCase _updateCategoryUseCase;
    private readonly DeleteCategoryUseCase _deleteCategoryUseCase;

    public CategoryController(
        CreateCategoryUseCase createCategoryUseCase,
        // GetEpiByIdUseCase getEpiByIdUseCase,
        UpdateCategoryUseCase updateCategoryUseCase,
        ListCategoriesUseCase listCategoriesUseCase,
        DeleteCategoryUseCase deleteCategoriesUseCase
    )
    {
        _createCategoryUseCase = createCategoryUseCase;
        _listCategoriesUseCase = listCategoriesUseCase;
        _updateCategoryUseCase = updateCategoryUseCase;
        _deleteCategoryUseCase = deleteCategoriesUseCase;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryRequest request)
    {
        var category = await _updateCategoryUseCase.ExecuteAsync(id, request);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _deleteCategoryUseCase.ExecuteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
