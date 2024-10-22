using Library.Entities.Books;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef.Books;

public class EfBookRepository(EfDataContext dbContext) : BookRepository
{
    public async Task<ShowBookDto?> GetById(int id)
    {
        return await dbContext.Set<Book>().Where(_ => _.Id == id).Select(_ =>
            new ShowBookDto()
            {
                Title = _.Title,
            }).FirstOrDefaultAsync();
    }

    public async Task Create(Book book)
    {
        await dbContext.Books.AddAsync(book);
    }

    public async Task<List<ShowAllBooksDto>> GetAll()
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
                LendsCount = b.Lends.Any()
                    ? b.Lends.Count
                    : 0,
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

    public async Task<Book?> Find(int id)
    {
        return await dbContext.Set<Book>().FirstOrDefaultAsync(_ => _.Id == id);
    }

    public void Update(Book book)
    {
        dbContext.Set<Book>().Update(book);
    }

    public void Delete(Book book)
    {
        dbContext.Set<Book>().Remove(book);
    }
}