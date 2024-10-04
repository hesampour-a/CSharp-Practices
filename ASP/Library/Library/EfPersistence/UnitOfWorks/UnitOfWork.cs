namespace Library.EfPersistence.UnitOfWorks;

public interface UnitOfWork
{
    Task SaveAsync();
}