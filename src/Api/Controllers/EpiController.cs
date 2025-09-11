using Microsoft.AspNetCore.Mvc;
using EpiManager.Application.UseCases;

[ApiController]
[Route("api/epi")]
public class EpisController : ControllerBase
{
    private readonly CreateEpiUseCase _createEpiUseCase;

    public EpisController(CreateEpiUseCase createEpiUseCase)
    {
        _createEpiUseCase = createEpiUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EpiRequest request)
    {
        var epi = await _createEpiUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id = epi.Id }, epi);
    }
}
