namespace Hospital.Api.EfPersistence;

public interface IUintOfWork
{
    Task Save();
}