using Library.Dtos.Lends;

namespace Library.Services.Lends;

public interface LendsService
{
    Task<ShowLendDto> GetByIdAsync(int id);
    Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId, int? userId);
    Task<int> CreateAsync(CreateLendDto lendDto);
    Task ReturnLendAsync(int id);
}