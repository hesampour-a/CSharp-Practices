using Library.Services.Rates.Contracts.Dtos;

namespace Library.Services.Rates.Contracts;

public interface RatesService
{
    Task CreateAsync(CreateRateDto createRateDto);
}