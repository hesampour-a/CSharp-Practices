namespace Library.Services.UnitOfWorks;

public interface UnitOfWork
{
    Task SaveAsync();
}