using FluentAssertions;
using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Users;
using Library.Persistence.Ef.Books;
using Library.Persistence.Ef.Lends;
using Library.Persistence.Ef.Rates;
using Library.Persistence.Ef.UnitOfWorks;
using Library.Persistence.Ef.Users;
using Library.Services.Lends;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Library.Services.Lends.Exceptions;
using Library.Services.Rates;
using Library.Services.Tests.Infrastructure.DataBaseConfig.Integration;

namespace Library.Services.Tests.Lends;

public class LendServiceTest : BusinessIntegrationTest
{
    private readonly LendsService _sut;

    public LendServiceTest()
    {
        var unitOfWork = new EfUnitOfWork(Context);
        var lendRepository = new EfLendRepository(Context);
        var userRepository = new EfUserRepository(Context);
        var bookRepository = new EfBookRepository(Context);
        var rateRepository = new EfRatesRepository(Context);
        var reatesService = new RatesAppService(unitOfWork, rateRepository);
        _sut = new LendsAppService(unitOfWork, lendRepository, userRepository,
            bookRepository, reatesService);
    }

    [Fact]
    public async Task Add_add_lend()
    {
        var user1 = new User()
        {
            Name = "John Doe",
            JoinDate = DateOnly.FromDateTime(DateTime.Today),
        };
        Save(user1);
        var book1 = new Book()
        {
            Title = "Book 1",
        };
        Save(book1);
        var dto = new CreateLendDto()
        {
            UserId = user1.Id,
            BookId = book1.Id
        };

        var result = await _sut.Create(dto);

        var actual = ReadContext.Set<Lend>().Single();

        actual.Should().BeEquivalentTo(new Lend()
        {
            BookId = dto.BookId,
            UserId = dto.UserId,
            IsReturned = false,
            LendDate = DateOnly.FromDateTime(DateTime.Today),
            ReturnDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(1)),
            Id = result
        });
    }
}