namespace Hospital.Api.EfPersistence;

public class UintOfWork(EfDataContext dbContext) : IUintOfWork
{
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
    
    public void Save()
    {
         dbContext.SaveChanges();
    }
}