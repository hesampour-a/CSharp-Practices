using Library.Dtos.Books;
using Library.Entities.Books;

namespace Library.Repositories.Books;

public interface BookRepository
{
    Task<Book?> GetByIdAsync(int id);
    Task CreateAsync(Book book);
    Task<IEnumerable<ShowBookDto>> GetAllAsync();
    Task<bool> CheckIfExistsByIdAsync(int userId);
}