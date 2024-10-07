using Library.Services.UnitOfWorks;

namespace Library.Persistence.Ef.UnitOfWorks;

public class EfUnitOfWork(EfDataContext dbContext) : UnitOfWork
{
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}