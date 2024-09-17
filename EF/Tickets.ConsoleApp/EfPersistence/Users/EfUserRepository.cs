using Tickets.ConsoleApp.Dtos.Users;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Users;

public class EfUserRepository(EfDataContext dbContext)
{
    public int Create(User newUser)
    {
        dbContext.Users.Add(newUser);
        return newUser.Id;
    }

    public List<ShowUserDto> GetAll()
    {
        return dbContext.Users.Select(_ => new ShowUserDto
        {
            Id = _.Id,
            FirstName = _.FirstName,
            LastName = _.LastName,
            NationalCode = _.NationalCode,
            PhoneNumber = _.PhoneNumber,
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