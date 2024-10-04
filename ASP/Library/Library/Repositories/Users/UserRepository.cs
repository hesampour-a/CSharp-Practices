using Library.Entities.Users;

namespace Library.Repositories.Users;

public interface UserRepository
{
    Task CreateAsync(User newUser);
    Task<User?> GetByIdAsync(int id);
    Task<bool> CheckIfExistsAsync(string userName);
    Task<bool> CheckIfExistsByIdAsync(int id);
    Task<int> CalculateYearsHistoryAsync(int UserId);
    Task<int> CurrentLendsCountAsync(int userId);
}