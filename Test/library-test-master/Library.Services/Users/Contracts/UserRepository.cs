using Library.Entities.Users;
using Library.Services.Users.Contracts.Dtos;

namespace Library.Services.Users.Contracts;

public interface UserRepository
{
    Task CreateAsync(User newUser);
    Task<ShowUserDto?> GetByIdAsync(int id);
    Task<bool> CheckIfExistsAsync(string userName);
    Task<bool> CheckIfExistsByIdAsync(int id);
    Task<int> CalculateYearsHistoryAsync(int UserId);
    Task<int> CurrentLendsCountAsync(int userId);
    Task<IEnumerable<ShowAllUsersDto>> GetAllAsync();
    Task<User?> FindById(int userId);
    void Update(User user);
    void Delete(User user);
}