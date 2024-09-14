using EfStoreSession6_Practice.Entities;

namespace EfStoreSession6_Practice.EFPersistance.Users;

public class EFUserRepository(EFDataContext context)
{
    public void Add(User user)
    {
        context.Set<User>().Add(user);
    }

    public User? GetById(int id)
    {
        return context.Set<User>().FirstOrDefault(_=>_.Id==id);
    }
}