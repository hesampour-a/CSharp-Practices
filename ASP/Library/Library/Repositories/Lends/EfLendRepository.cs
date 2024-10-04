using Library.Dtos.Lends;
using Library.EfPersistence;
using Library.Entities.Lends;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Lends;

public class EfLendRepository(EfDataContext dbContext) : LendRepository
{
    public async Task<Lend> GetByIdAsync(int id)
    {
        return await dbContext.Lends.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId,
        int? userId)
    {
        var baseQuery = dbContext.Lends;

        if (bookId != null)
            baseQuery.Where(_ => _.BookId == bookId);
        if (userId != null)
            baseQuery.Where(_ => _.UserId == userId);

        return await baseQuery.Select(_ => new ShowLendDto
        {
            BookId = _.BookId,
            Id = _.Id,
            UserId = _.UserId,
            LendDate = _.LendDate,
            ReturnDate = _.ReturnDate,
            IsReturned = _.IsReturned,
        }).ToListAsync();
    }

    public async Task CreateAsync(Lend newLend)
    {
        await dbContext.Lends.AddAsync(newLend);
    }
}