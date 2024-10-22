using Library.Entities.Books;
using Library.Services.Books.Contracts.Dtos;

namespace Library.Services.Books.Contracts;

public interface BookRepository
{
    Task<ShowBookDto?> GetById(int id);
    Task Create(Book book);
    Task<List<ShowAllBooksDto>> GetAll();
    Task<bool> CheckIfExistsByIdAsync(int userId);
    Task<Book?> Find(int id);
    void Update(Book book);
    void Delete(Book book);
}