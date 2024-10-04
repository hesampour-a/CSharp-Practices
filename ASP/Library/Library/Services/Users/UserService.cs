using Library.Dtos.Users;

namespace Library.Services.Users;

public interface UserService
{
    Task<int> CreateAsync(CreateUserDto userDto);
    Task<ShowUserDto> GetByIdAsync(int id);
}