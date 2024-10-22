using Library.Entities.Lends;
using Library.Services.Lends.Contracts.Dtos;

namespace Library.Services.Lends.Contracts;

public interface LendRepository
{
    Task Create(Lend newLend);
    Task<Lend?> Find(int id);
}