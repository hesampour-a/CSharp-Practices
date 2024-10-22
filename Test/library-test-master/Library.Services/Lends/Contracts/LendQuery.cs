using Library.Entities.Lends;
using Library.Services.Lends.Contracts.Dtos;

namespace Library.Services.Lends.Contracts;

public interface LendQuery
{
    Task<Lend> GetById(int id);

    Task<IEnumerable<ShowLendDto>> GetAll(int? bookId = null,
        int? userId = null);

    Task<IEnumerable<ShowActiveLendDto>> GetAllActives(int? bookId = null,
        int? userId = null);
}