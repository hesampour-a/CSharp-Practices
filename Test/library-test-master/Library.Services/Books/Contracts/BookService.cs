using Library.Services.Books.Contracts.Dtos;

namespace Library.Services.Books.Contracts;

public interface BookService
{
    Task<ShowBookDto?> GetById(int id);
    Task<int> Create(CreateBookDto bookDto);
    Task<List<ShowAllBooksDto>> GetAll();
    Task Update(int id, UpdateBookDto dto);
    Task Delete(int id);
}