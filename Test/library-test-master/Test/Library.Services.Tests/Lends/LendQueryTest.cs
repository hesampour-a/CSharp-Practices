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
using Library.Services.Rates;
using Library.Services.Tests.Infrastructure.DataBaseConfig.Integration;

namespace Library.Services.Tests.Lends;

public class LendQueryTest : BusinessIntegrationTest
{
    private readonly LendQuery _sut;

    public LendQueryTest()
    {
        _sut = new EfLendQuery(Context);
    }

    [Fact]
    public async Task GetById_get_by_id()
    {
        var user1 = CreaUser();
        Save(user1);
        var book1 = CreateBook("mamad");
        Save(book1);
        var lend1 = CreateLend(book1.Id, user1.Id);
        Save(lend1);
        var user2 = CreaUser("Ahmad");
        Save(user2);
        var book2 = CreateBook("Book");
        Save(book2);
        var lend2 = CreateLend(book2.Id, user2.Id);
        Save(lend2);

        var actual = await _sut.GetById(lend2.Id);

        actual.Should().BeEquivalentTo(new ShowLendDto()
        {
            Id = lend2.Id,
            IsReturned = lend2.IsReturned,
            ReturnDate = lend2.ReturnDate,
            LendDate = lend2.LendDate,
            UserId = lend2.UserId,
            BookId = lend2.BookId,
        });
    }


    [Fact]
    public async Task GetAll_get_all()
    {
        var user1 = CreaUser();
        Save(user1);
        var book1 = CreateBook("mamad");
        Save(book1);
        var lend1 = CreateLend(book1.Id, user1.Id);
        Save(lend1);
        var user2 = CreaUser("Ahmad");
        Save(user2);
        var book2 = CreateBook("Book");
        Save(book2);
        var lend2 = CreateLend(book2.Id, user2.Id);
        Save(lend2);

        var actual = await _sut.GetAll();

        actual.Should().HaveCount(2);
        actual.Should().ContainEquivalentOf(
            new ShowLendDto()
            {
                Id = lend2.Id,
                IsReturned = lend2.IsReturned,
                ReturnDate = lend2.ReturnDate,
                LendDate = lend2.LendDate,
                UserId = lend2.UserId,
                BookId = lend2.BookId,
            });
        actual.Should().ContainEquivalentOf(
            new ShowLendDto()
            {
                Id = lend1.Id,
                IsReturned = lend1.IsReturned,
                ReturnDate = lend1.ReturnDate,
                LendDate = lend1.LendDate,
                UserId = lend1.UserId,
                BookId = lend1.BookId,
            });
    }

    [Fact]
    public async Task GetAll_filter_by_book_Id()
    {
        var user1 = CreaUser();
        Save(user1);
        var book1 = CreateBook("mamad");
        Save(book1);
        var lend1 = CreateLend(book1.Id, user1.Id);
        Save(lend1);
        var user2 = CreaUser("Ahmad");
        Save(user2);
        var book2 = CreateBook("Book");
        Save(book2);
        var lend2 = CreateLend(book2.Id, user2.Id);
        Save(lend2);

        var actual = await _sut.GetAll(book1.Id);

        actual.Should().HaveCount(1);

        actual.Should().ContainEquivalentOf(
            new ShowLendDto()
            {
                Id = lend1.Id,
                IsReturned = lend1.IsReturned,
                ReturnDate = lend1.ReturnDate,
                LendDate = lend1.LendDate,
                UserId = lend1.UserId,
                BookId = lend1.BookId,
            });
    }

    [Fact]
    public async Task GetAll_filter_by_user_Id()
    {
        var user1 = CreaUser();
        Save(user1);
        var book1 = CreateBook("mamad");
        Save(book1);
        var lend1 = CreateLend(book1.Id, user1.Id);
        Save(lend1);
        var user2 = CreaUser("Ahmad");
        Save(user2);
        var book2 = CreateBook("Book");
        Save(book2);
        var lend2 = CreateLend(book2.Id, user2.Id);
        Save(lend2);

        var actual = await _sut.GetAll(null, user1.Id);

        actual.Should().HaveCount(1);

        actual.Should().ContainEquivalentOf(
            new ShowLendDto()
            {
                Id = lend1.Id,
                IsReturned = lend1.IsReturned,
                ReturnDate = lend1.ReturnDate,
                LendDate = lend1.LendDate,
                UserId = lend1.UserId,
                BookId = lend1.BookId,
            });
    }

    [Fact]
    public async Task GetAllActives_get_all_actives()
    {
        var user1 = CreaUser();
        Save(user1);
        var book1 = CreateBook("mamad");
        Save(book1);
        var lend1 = CreateLend(book1.Id, user1.Id);
        lend1.IsReturned = true;
        Save(lend1);
        var user2 = CreaUser("Ahmad");
        Save(user2);
        var book2 = CreateBook("Book");
        Save(book2);
        var lend2 = CreateLend(book2.Id, user2.Id);
        Save(lend2);

        var actual = await _sut.GetAllActives();

        actual.Should().HaveCount(1);
    }

    private static Book CreateBook(string name = "dummy book title")
    {
        return new Book()
        {
            Title = name,
        };
    }

    private static Lend CreateLend(int bookId, int userId)
    {
        return new Lend()
        {
            BookId = bookId,
            UserId = userId,
            IsReturned = false,
            LendDate = DateOnly.FromDateTime(DateTime.Today),
            ReturnDate = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
        };
    }

    private static User CreaUser(string name = "dummy title")
    {
        return new User()
        {
            Name = name,
            JoinDate = DateOnly.FromDateTime(DateTime.Today),
        };
    }
}