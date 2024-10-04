using Library.Dtos.Books;

namespace Library.Services.Books;

public interface BookService
{
    Task<ShowBookDto> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateBookDto bookDto);
    Task<IEnumerable<ShowBookDto>> GetAllAsync();
}