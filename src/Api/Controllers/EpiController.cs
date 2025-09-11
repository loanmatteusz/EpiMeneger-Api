using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;

[ApiController]
[Route("api/epi")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;
    private readonly GetEpiByIdUseCase _getEpiByIdUseCase;

    public EpisController(CreateEpiUseCase createEpiUseCase, GetEpiByIdUseCase getEpiByIdUseCase)
    {
        _createEpiUseCase = createEpiUseCase;
        _getEpiByIdUseCase = getEpiByIdUseCase;
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
}
