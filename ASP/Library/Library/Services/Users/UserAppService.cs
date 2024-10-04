using Library.Dtos.Users;
using Library.EfPersistence.UnitOfWorks;
using Library.Entities.Users;
using Library.Repositories.Users;

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
            JoinDate = DateOnly.FromDateTime(DateTime.Today),
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
            JoinDate = user.JoinDate,
        };
    }
}