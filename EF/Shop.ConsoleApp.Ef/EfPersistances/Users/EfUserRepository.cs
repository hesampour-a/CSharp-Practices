using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Users;

public class EfUserRepository(EfDataContext dbContext)
{
    public void Create(User user)
    {
        dbContext.Users.Add(user);
    }

    public User? GetById(int id)
    {
        return dbContext.Users.FirstOrDefault(_=>_.Id == id);
    }
}