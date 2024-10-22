using FluentAssertions;
using Library.Entities.Books;
using Library.Persistence.Ef.Books;
using Library.Persistence.Ef.UnitOfWorks;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Library.Services.Books.Exceptions;
using Library.Services.Tests.Infrastructure.DataBaseConfig.Integration;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.Tests.Books;

public class BookServiceTest : BusinessIntegrationTest
{
    private readonly BookService _sut; //Test Driven Development

    public BookServiceTest()
    {
        var bookRepository = new EfBookRepository(Context);
        var unitOfWork = new EfUnitOfWork(Context);
        _sut = new BookAppService(unitOfWork, bookRepository);
    }

    [Fact]
    public async Task GetById_get_user_by_id_properly()
    {
        var book1 = CreateBook();
        Save(book1);

        var book2 = CreateBook();
        Save(book2);


        var actual = await _sut.GetById(book1.Id);

        actual.Should().NotBeNull();
        actual.Title.Should().Be(book1.Title);
    }

    [Fact]
    public async Task Create_book_properly()
    {
        var dto = new CreateBookDto()
        {
            Title = "Test Book",
        };
        var result = await _sut.Create(dto);

        var actual = await ReadContext.Set<Book>().SingleAsync();

        actual.Title.Should().Be(dto.Title);
        result.Should().Be(actual.Id);
    }

    [Fact]
    public async Task GetAll_get_all_books_properly()
    {
        var book1 = CreateBook();
        Save(book1);

        var book2 = CreateBook("Test Book");
        Save(book2);

        var actual = await _sut.GetAll();

        actual.Should().HaveCount(2);

        actual.Should().Contain(_ => _.Title == book1.Title);
        actual.Should().Contain(_ => _.Title == book2.Title);
        actual.Should().Contain(_ => _.Id == book1.Id);
        actual.Should().Contain(_ => _.Id == book2.Id);
    }

    [Fact]
    public async Task Update_update_book_properly()
    {
        var book1 = CreateBook();
        Save(book1);

        var book2 = CreateBook("Test Book");
        Save(book2);

        var dto = new UpdateBookDto()
        {
            Title = "Updated Book",
        };

        await _sut.Update(book2.Id, dto);

        var actual = await ReadContext.Set<Book>()
            .FirstOrDefaultAsync(_ => _.Id == book2.Id);

        actual.Title.Should().Be(dto.Title);
    }

    [Fact]
    public async Task Update_throw_exception_when_book_not_found()
    {
        int dummyId = -1;

        var actual = () => _sut.Update(dummyId, new UpdateBookDto());

        await actual.Should().ThrowExactlyAsync<BookNotFoundException>();
    }

    [Fact]
    public async Task Delete_delete_book_properly()
    {
        var book1 = CreateBook();
        Save(book1);
        var book2 = CreateBook();
        Save(book2);

        await _sut.Delete(book2.Id);

        var actual = await ReadContext.Set<Book>().ToListAsync();

        actual.Should().HaveCount(1);
        actual.Should().Contain(_ => _.Id == book1.Id);
        actual.Should().NotContain(_ => _.Id == book2.Id);
    }

    private static Book CreateBook(string name = "dummy")
    {
        var book = new Book()
        {
            Title = name
        };
        return book;
    }
}