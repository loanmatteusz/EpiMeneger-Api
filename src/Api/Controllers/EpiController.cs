using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;

[ApiController]
[Route("api/epi")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;
    private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListEpisUseCase _listEpisUseCase;
    private readonly DeleteEpiUseCase _deleteEpiUseCase;

    public EpisController(
        CreateEpiUseCase createEpiUseCase,
        GetEpiByIdUseCase getEpiByIdUseCase,
        ListEpisUseCase listEpisUseCase,
        DeleteEpiUseCase deleteEpiUseCase
    )
    {
        _createEpiUseCase = createEpiUseCase;
        _getEpiByIdUseCase = getEpiByIdUseCase;
        _listEpisUseCase = listEpisUseCase;
        _deleteEpiUseCase = deleteEpiUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EpiRequest request)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _deleteEpiUseCase.ExecuteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
