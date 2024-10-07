using Library.Entities.Rates;

namespace Library.Services.Rates.Contracts;

public interface RatesRepository
{
    Task CreateAsync(Rate rate);
}