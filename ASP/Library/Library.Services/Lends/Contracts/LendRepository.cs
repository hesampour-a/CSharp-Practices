using Library.Entities.Lends;
using Library.Services.Lends.Contracts.Dtos;

namespace Library.Services.Lends.Contracts;

public interface LendRepository
{
    Task<Lend> GetByIdAsync(int id);
    Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId, int? userId);
    Task CreateAsync(Lend newLend);

    Task<IEnumerable<ShowActiveLendDto>> GetAllActivesAsync(int? bookId,
        int? userId);
}