namespace Hospital.Api.EfPersistence;

public class UintOfWork(EfDataContext dbContext) : IUintOfWork
{
    public async Task Save()
    {
        await dbContext.SaveChangesAsync();
    }
}