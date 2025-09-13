using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;
using EpiManager.Api.DTOs;

[ApiController]
[Route("api/v1/epis")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;
    private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListEpisUseCase _listEpisUseCase;
    private readonly UpdateEpiUseCase _updateEpiUseCase;
    private readonly PatchEpiUseCase _patchEpiUseCase;
    private readonly DeleteEpiUseCase _deleteEpiUseCase;

    public EpisController(
        CreateEpiUseCase createEpiUseCase,
        GetEpiByIdUseCase getEpiByIdUseCase,
        ListEpisUseCase listEpisUseCase,
        UpdateEpiUseCase updateEpiUseCase,
        PatchEpiUseCase patchEpiUseCase,
        DeleteEpiUseCase deleteEpiUseCase
    )
    {
        _createEpiUseCase = createEpiUseCase;
        _getEpiByIdUseCase = getEpiByIdUseCase;
        _listEpisUseCase = listEpisUseCase;
        _updateEpiUseCase = updateEpiUseCase;
        _patchEpiUseCase = patchEpiUseCase;
        _deleteEpiUseCase = deleteEpiUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEpiRequest request)
    {
        var epiResponse = await _createEpiUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id = epiResponse.Id }, epiResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var epi = await _getEpiByIdUseCase.ExecuteAsync(id);
        if (epi == null) return NotFound();
        return Ok(epi);
    }

    [HttpGet]
    public async Task<IActionResult> List(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? name = null,
        [FromQuery] int? ca = null,
        [FromQuery] string? category = null
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
        var result = await _listEpisUseCase.ExecuteAsync(page, pageSize, name, ca, category);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEpiRequest request)
    {
        var epi = await _updateEpiUseCase.ExecuteAsync(id, request);
        if (epi == null) return NotFound();
        return Ok(epi);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] PatchEpiRequest request)
    {
        var epi = await _patchEpiUseCase.ExecuteAsync(id, request);
        if (epi == null) return NotFound();
        return Ok(epi);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _deleteEpiUseCase.ExecuteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
