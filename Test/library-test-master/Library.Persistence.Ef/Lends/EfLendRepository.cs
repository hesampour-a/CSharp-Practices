using Library.Entities.Lends;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef.Lends;

public class EfLendRepository(EfDataContext dbContext) : LendRepository
{
    public async Task Create(Lend newLend)
    {
        await dbContext.Lends.AddAsync(newLend);
    }

    public async Task<Lend?> Find(int id)
    {
        return await dbContext.Set<Lend>().FirstOrDefaultAsync(x => x.Id == id);
    }
}