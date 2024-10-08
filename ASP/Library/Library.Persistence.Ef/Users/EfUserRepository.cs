using Library.Entities.Users;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef.Users;

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

    public async Task<IEnumerable<ShowAllUsersDto>> GetAllAsync()
    {
        return await dbContext.Users.Select(_ => new ShowAllUsersDto
        {
            Id = _.Id,
            JoinDate = _.JoinDate,
            Name = _.Name,
            Penalty = (from user in dbContext.Users
                join lend in dbContext.Lends
                    on user.Id equals lend.UserId
                where user.Id == _.Id && lend.IsReturned == false &&
                      lend.ReturnDate < DateOnly.FromDateTime(DateTime.Now)
                group lend by user.Id
                into g
                select new
                {
                    Days = g.Sum(l => DateTime.Now.Day - l.ReturnDate.Day)
                }).Select(_ => _.Days).FirstOrDefault()
        }).ToListAsync();
    }
}