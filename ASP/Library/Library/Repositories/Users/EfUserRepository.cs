using Library.EfPersistence;
using Library.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Users;

public class EfUserRepository(EfDataContext dbContext) : UserRepository
{
    public async Task CreateAsync(User newUser)
    {
        await dbContext.Users.AddAsync(newUser);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await dbContext.Users.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<bool> CheckIfExistsAsync(string userName)
    {
        return await dbContext.Users.AnyAsync(_ => _.Name == userName);
    }

    public async Task<bool> CheckIfExistsByIdAsync(int id)
    {
        return await dbContext.Users.AnyAsync(_ => _.Id == id);
    }

    public async Task<int> CalculateYearsHistoryAsync(int UserId)
    {
        var temp = await dbContext.Users.Where(_ => _.Id == UserId).Select(_ =>
            new
            {
                History = DateTime.Now.Year - _.JoinDate.Year
            }).FirstAsync();
        return temp.History;
    }

    public async Task<int> CurrentLendsCountAsync(int userId)
    {
        return await dbContext.Lends
            .Where(_ => _.UserId == userId && _.IsReturned == false)
            .CountAsync();
    }
}