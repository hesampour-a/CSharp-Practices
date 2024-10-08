using Library.Entities.Rates;
using Library.Services.Rates.Contracts;
using Library.Services.Rates.Contracts.Dtos;
using Library.Services.UnitOfWorks;

namespace Library.Services.Rates;

public class RatesAppService(
    UnitOfWork unitOfWork,
    RatesRepository ratesRepository) : RatesService
{
    public async Task CreateAsync(CreateRateDto createRateDto)
    {
        await ratesRepository.CreateAsync(new Rate
        {
            BookId = createRateDto.BookId,
            Score = createRateDto.Score
        });
    }
}