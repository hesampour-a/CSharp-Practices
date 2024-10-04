using Library.Dtos.Lends;
using Library.Entities.Lends;

namespace Library.Repositories.Lends;

public interface LendRepository
{
    Task<Lend> GetByIdAsync(int id);
    Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId, int? userId);
    Task CreateAsync(Lend newLend);
}