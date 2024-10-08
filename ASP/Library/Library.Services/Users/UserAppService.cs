using Library.Entities.Users;
using Library.Services.UnitOfWorks;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;

namespace Library.Services.Users;

public class UserAppService(
    UnitOfWork unitOfWork,
    UserRepository userRepository) : UserService
{
    public async Task<int> CreateAsync(CreateUserDto userDto)
    {
        if (await userRepository.CheckIfExistsAsync(userDto.Name))
            throw new Exception("User already exists");

        var newUser = new User
        {
            Name = userDto.Name,
            JoinDate = DateOnly.FromDateTime(DateTime.Today)
        };
        await userRepository.CreateAsync(newUser);
        await unitOfWork.SaveAsync();
        return newUser.Id;
    }

    public async Task<ShowUserDto> GetByIdAsync(int id)
    {
        var user = await userRepository.GetByIdAsync(id)
                   ?? throw new Exception("User not found");
        return new ShowUserDto
        {
            Id = user.Id,
            Name = user.Name,
            JoinDate = user.JoinDate
        };
    }

    public async Task<IEnumerable<ShowAllUsersDto>> GetAllAsync()
    {
        var dtos = await userRepository.GetAllAsync();
        foreach (var dto in dtos) dto.Penalty *= 20000;

        return dtos;
    }
}