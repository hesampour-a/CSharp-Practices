using Library.Services.Users.Contracts.Dtos;

namespace Library.Services.Users.Contracts;

public interface UserService
{
    Task<int> CreateAsync(CreateUserDto userDto);
    Task<ShowUserDto> GetByIdAsync(int id);
    Task<IEnumerable<ShowAllUsersDto>> GetAllAsync();
}