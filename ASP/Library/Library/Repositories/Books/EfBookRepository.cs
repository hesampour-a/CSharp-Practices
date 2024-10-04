using Library.Dtos.Books;
using Library.EfPersistence;
using Library.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Books;

public class EfBookRepository(EfDataContext dbContext) : BookRepository
{
    public async Task<Book?> GetByIdAsync(int id)
    {
        return await dbContext.Books.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task CreateAsync(Book book)
    {
        await dbContext.Books.AddAsync(book);
    }

    public async Task<IEnumerable<ShowBookDto>> GetAllAsync()
    {
        return await dbContext.Books.Select(_ => new ShowBookDto
        {
            Id = _.Id,
            Title = _.Title,
        }).ToListAsync();
    }

    public async Task<bool> CheckIfExistsByIdAsync(int lendDtoBookId)
    {
        return await dbContext.Books.AnyAsync(_ => _.Id == lendDtoBookId);
    }
}