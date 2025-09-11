using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/metrics")]
public class MetricsController : ControllerBase
{
    private readonly GetEpiMetricsUseCase _useCase;

    public MetricsController(GetEpiMetricsUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetMetrics()
    {
        var metrics = await _useCase.ExecuteAsync();
        return Ok(metrics);
    }
}
