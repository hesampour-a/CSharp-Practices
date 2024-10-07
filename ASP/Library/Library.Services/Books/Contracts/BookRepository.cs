using Library.Entities.Books;
using Library.Services.Books.Contracts.Dtos;

namespace Library.Services.Books.Contracts;

public interface BookRepository
{
    Task<Book?> GetByIdAsync(int id);
    Task CreateAsync(Book book);
    Task<IEnumerable<ShowAllBooksDto>> GetAllAsync();
    Task<bool> CheckIfExistsByIdAsync(int userId);
}