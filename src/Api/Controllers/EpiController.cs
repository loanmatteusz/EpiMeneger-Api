using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;
using EpiManager.Api.DTOs;

[ApiController]
[Route("api/v1/epi")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;
    private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListEpisUseCase _listEpisUseCase;
    private readonly UpdateEpiUseCase _updateEpiUseCase;
    private readonly DeleteEpiUseCase _deleteEpiUseCase;

    public EpisController(
        CreateEpiUseCase createEpiUseCase,
        GetEpiByIdUseCase getEpiByIdUseCase,
        ListEpisUseCase listEpisUseCase,
        UpdateEpiUseCase updateEpiUseCase,
        DeleteEpiUseCase deleteEpiUseCase
    )
    {
        _createEpiUseCase = createEpiUseCase;
        _getEpiByIdUseCase = getEpiByIdUseCase;
        _listEpisUseCase = listEpisUseCase;
        _updateEpiUseCase = updateEpiUseCase;
        _deleteEpiUseCase = deleteEpiUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEpiRequest request)
    {
        var epi = await _createEpiUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id = epi.Id }, epi);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var epi = await _getEpiByIdUseCase.ExecuteAsync(id);
        if (epi == null) return NotFound();
        return Ok(epi);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var epis = await _listEpisUseCase.ExecuteAsync();
        return Ok(epis);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] UpdateEpiRequest request)
    {
        var epi = await _updateEpiUseCase.ExecuteAsync(id, request);
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
