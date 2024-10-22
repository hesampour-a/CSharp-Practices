using Library.Entities.Books;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Library.Services.Books.Exceptions;
using Library.Services.UnitOfWorks;

namespace Library.Services.Books;

public class BookAppService(
    UnitOfWork unitOfWork,
    BookRepository bookRepository) : BookService
{
    public async Task<ShowBookDto?> GetById(int id)
    {
        return await bookRepository.GetById(id);
    }

    public async Task<int> Create(CreateBookDto bookDto)
    {
        var newBook = new Book
        {
            Title = bookDto.Title
        };
        await bookRepository.Create(newBook);
        await unitOfWork.SaveAsync();
        return newBook.Id;
    }

    public async Task<List<ShowAllBooksDto>> GetAll()
    {
        return await bookRepository.GetAll();
    }

    public async Task Update(int id, UpdateBookDto dto)
    {
        var book = await bookRepository.Find(id)
                   ?? throw new BookNotFoundException();

        book.Title = dto.Title;
        bookRepository.Update(book);

        await unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var book = await bookRepository.Find(id)
                   ?? throw new BookNotFoundException();

        bookRepository.Delete(book);
        await unitOfWork.SaveAsync();
    }
}