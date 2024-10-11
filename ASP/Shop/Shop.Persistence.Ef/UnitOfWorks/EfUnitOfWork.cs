using Shop.Persistence.Ef.Data;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Persistence.Ef.UnitOfWorks;

public class EfUnitOfWork(EfDataContext dbContext) : UnitOfWork
{
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task BeginAsync()
    {
        await dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
        await dbContext.Database.CommitTransactionAsync();
    }

    public async Task RoleBackAsync()
    {
        await dbContext.Database.RollbackTransactionAsync();
    }
}