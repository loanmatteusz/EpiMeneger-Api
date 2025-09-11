using EpiManager.Application.DTOs;
using EpiManager.Application.Interfaces;

public class GetEpiMetricsUseCase
{
    private readonly IEpiRepository _repository;

    public GetEpiMetricsUseCase(IEpiRepository repository)
    {
        _repository = repository;
    }

    public async Task<EpiMetricsResponse> ExecuteAsync()
    {
        var total = await _repository.CountAsync();
        var perCategory = await _repository.CountByCategoryAsync();
        var expired = await _repository.CountExpiringSoonAsync(7);

        return new EpiMetricsResponse
        {
            Total = total,
            Expired = expired,
            ByCategory = perCategory
        };
    }
}
