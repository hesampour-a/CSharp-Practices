using Library.Entities.Rates;
using Library.Services.Rates.Contracts;
using Library.Services.Rates.Contracts.Dtos;
using Library.Services.UnitOfWorks;

namespace Library.Services.Rates;

public class RatesAppService(
    UnitOfWork unitOfWork,
    RatesRepository ratesRepository) : RatesService
{
    public async Task<int> Create(CreateRateDto createRateDto)
    {
        var newRate = new Rate
        {
            BookId = createRateDto.BookId,
            Score = createRateDto.Score
        };
        await ratesRepository.CreateAsync(newRate);
        await unitOfWork.SaveAsync();
        return newRate.Id;
    }
}