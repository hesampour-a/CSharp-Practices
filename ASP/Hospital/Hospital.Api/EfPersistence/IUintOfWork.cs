namespace Hospital.Api.EfPersistence;

public interface IUintOfWork
{
    Task SaveAsync();
    void Save();
}