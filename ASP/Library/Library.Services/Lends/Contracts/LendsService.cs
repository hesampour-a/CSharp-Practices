using Library.Services.Lends.Contracts.Dtos;

namespace Library.Services.Lends.Contracts;

public interface LendsService
{
    Task<ShowLendDto> GetByIdAsync(int id);
    Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId, int? userId);
    Task<int> CreateAsync(CreateLendDto lendDto);
    Task ReturnLendAsync(int id);

    Task<IEnumerable<ShowActiveLendDto>> GetAllActivesAsync(int? bookId,
        int? userId);
}