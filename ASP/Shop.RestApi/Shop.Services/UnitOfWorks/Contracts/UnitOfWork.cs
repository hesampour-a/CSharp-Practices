namespace Shop.Services.UnitOfWorks.Contracts;

public interface UnitOfWork
{
    Task SaveAsync();
    Task BeginAsync();
    Task CommitAsync();
    Task RoleBackAsync();
}