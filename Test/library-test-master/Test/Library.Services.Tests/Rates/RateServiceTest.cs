using FluentAssertions;
using Library.Entities.Books;
using Library.Entities.Rates;
using Library.Persistence.Ef.Rates;
using Library.Persistence.Ef.UnitOfWorks;
using Library.Services.Rates;
using Library.Services.Rates.Contracts;
using Library.Services.Rates.Contracts.Dtos;
using Library.Services.Tests.Infrastructure.DataBaseConfig.Integration;

namespace Library.Services.Tests.Rates;

public class RateServiceTest : BusinessIntegrationTest
{
    private readonly RatesService _sut;

    public RateServiceTest()
    {
        var unitOfWork = new EfUnitOfWork(Context);
        var rateRepository = new EfRatesRepository(Context);
        _sut = new RatesAppService(unitOfWork, rateRepository);
    }

    [Fact]
    public async Task Create_create_new_rate()
    {
        var book1 = new Book()
        {
            Title = "Book 1",
        };
        Save(book1);
        var dto = new CreateRateDto()
        {
            BookId = book1.Id,
            Score = 5
        };


        var result = await _sut.Create(dto);

        var actual = ReadContext.Set<Rate>().Single();

        actual.Should().BeEquivalentTo(new Rate()
        {
            BookId = dto.BookId,
            Score = dto.Score,
            Id = result
        });
    }
}