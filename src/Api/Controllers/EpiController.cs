using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;

[ApiController]
[Route("api/epi")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;
    private readonly GetEpiByIdUseCase _getEpiByIdUseCase;
    private readonly ListEpisUseCase _listEpisUseCase;

    public EpisController(
        CreateEpiUseCase createEpiUseCase,
        GetEpiByIdUseCase getEpiByIdUseCase,
        ListEpisUseCase listEpisUseCase
    )
    {
        _createEpiUseCase = createEpiUseCase;
        _getEpiByIdUseCase = getEpiByIdUseCase;
        _listEpisUseCase = listEpisUseCase;
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
}
