using Library.Entities.Rates;
using Library.Services.Rates.Contracts;

namespace Library.Persistence.Ef.Rates;

public class EfRatesRepository(EfDataContext dbContext) : RatesRepository
{
    public async Task CreateAsync(Rate rate)
    {
        await dbContext.Rates.AddAsync(rate);
    }
}