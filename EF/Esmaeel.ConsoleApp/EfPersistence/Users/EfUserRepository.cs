using Esmaeel.ConsoleApp.Dtos.Users;
using Esmaeel.ConsoleApp.Entities;

namespace Esmaeel.ConsoleApp.EfPersistence.Users;

public class EfUserRepository(EfDataContext dbContext)
{
    public int Create(User user)
    {
        dbContext.Users.Add(user);
        // dbContext.Set<User>().Add(user); //best practice
        return user.Id;
    }

    public List<ShowUserDto> GetAll()
    {
        // return (from user in dbContext.Users
        //     join store in dbContext.Stores
        //         on user.StoreId equals store.Id
        //     select new ShowUserDto
        //     {
        //         Id = user.Id,
        //         Name = user.Name,
        //         StoreName = store.Name,
        //     }).ToList();
        return dbContext.Users.Select(_ => new ShowUserDto
        {
            Id = _.Id,
            Name = _.Name,
            
        }).ToList();
    }

    public User? GetById(int userId)
    {
        return dbContext.Users.FirstOrDefault(_ => _.Id == userId);
    }

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }
}