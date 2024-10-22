namespace ServiceCharge.Services.UnitOfWorks;

public interface UnitOfWork
{
    Task SaveAsync();
    Task Begin();
    Task Rollback();
    Task Commit();
}