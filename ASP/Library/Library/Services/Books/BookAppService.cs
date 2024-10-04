using Library.Dtos.Books;
using Library.EfPersistence.UnitOfWorks;
using Library.Entities.Books;
using Library.Repositories.Books;

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
            Title = book.Title,
        };
    }

    public async Task<int> CreateAsync(CreateBookDto bookDto)
    {
        var newBook = new Book
        {
            Title = bookDto.Title,
        };
        await bookRepository.CreateAsync(newBook);
        await unitOfWork.SaveAsync();
        return newBook.Id;
    }

    public async Task<IEnumerable<ShowBookDto>> GetAllAsync()
    {
        return await bookRepository.GetAllAsync();
    }
}