using Library.Entities.Books;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef.Books;

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

    public async Task<IEnumerable<ShowAllBooksDto>> GetAllAsync()
    {
        // return await dbContext.Books.Select(_ => new ShowBookDto
        // {
        //     Id = _.Id,
        //     Title = _.Title
        // }).ToListAsync();
        return await dbContext.Books
            .Include(b => b.Lends)
            .Include(_ => _.Rates)
            .Select(b => new ShowAllBooksDto
            {
                Id = b.Id,
                Title = b.Title,
                LendsCount = b.Lends.Count,
                AverageScore = b.Rates.Any()
                    ? b.Rates.Average(_ => _.Score)
                    : 0
            })
            .OrderByDescending(b => b.AverageScore)
            .ToListAsync();

        // return await dbContext.Books.Include(_ => _.Lends)
        //     .ThenInclude(_ => _.Rate).Select(_ => new ShowAllBooksDto
        //     {
        //         Id = _.Id,
        //         Title = _.Title,
        //         LendsCount = _.Lends.Count,
        //         AverageScore = _.Lends.Average(l => l.Rate.Score)
        //     }).OrderByDescending(_ => _.AverageScore).ToListAsync();
    }

    public async Task<bool> CheckIfExistsByIdAsync(int lendDtoBookId)
    {
        return await dbContext.Books.AnyAsync(_ => _.Id == lendDtoBookId);
    }
}