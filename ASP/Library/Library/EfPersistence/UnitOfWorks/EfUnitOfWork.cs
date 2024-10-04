namespace Library.EfPersistence.UnitOfWorks;

public class EfUnitOfWork(EfDataContext dbContext) : UnitOfWork
{
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}