using Library.Entities.Books;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Library.Services.UnitOfWorks;

namespace Library.Services.Books;

public class BookAppService(
    UnitOfWork unitOfWork,
    BookRepository bookRepository) : BookService
{
    public async Task<ShowBookDto> GetByIdAsync(int id)
    {
        var book = await bookRepository.GetByIdAsync(id)
                   ?? throw new Exception("Book not found");

        return new ShowBookDto
        {
            Id = book.Id,
            Title = book.Title
        };
    }

    public async Task<int> CreateAsync(CreateBookDto bookDto)
    {
        var newBook = new Book
        {
            Title = bookDto.Title
        };
        await bookRepository.CreateAsync(newBook);
        await unitOfWork.SaveAsync();
        return newBook.Id;
    }

    public async Task<IEnumerable<ShowAllBooksDto>> GetAllAsync()
    {
        return await bookRepository.GetAllAsync();
    }
}