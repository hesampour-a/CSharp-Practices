using Library.Entities.Rates;
using Library.Services.Rates.Contracts.Dtos;
using Library.Services.UnitOfWorks;

namespace Library.Services.Rates.Contracts;

public interface RatesService
{
    Task CreateAsync(CreateRateDto createRateDto);
}