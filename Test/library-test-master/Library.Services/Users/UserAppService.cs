using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Users;
using Library.Services.UnitOfWorks;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using Library.Services.Users.Exceptions;

namespace Library.Services.Users;

public class UserAppService(
    UnitOfWork unitOfWork,
    UserRepository userRepository) : UserService
{
    public async Task<int> CreateAsync(CreateUserDto userDto)
    {
        if (await userRepository.CheckIfExistsAsync(userDto.Name))
            throw new UserDuplicateException();

        var newUser = new User
        {
            Name = userDto.Name,
            JoinDate = DateOnly.FromDateTime(DateTime.Today)
        };

        await userRepository.CreateAsync(newUser);
        await unitOfWork.SaveAsync();
        return newUser.Id;
    }

    public async Task<ShowUserDto?> GetById(int id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ShowAllUsersDto>> GetAll()
    {
        var dtos = await userRepository.GetAllAsync();
        foreach (var dto in dtos) dto.Penalty *= 20000;

        return dtos;
    }

    public async Task Update(int userId, UserUpdateDto dto)
    {
        var user = await userRepository.FindById(userId)
                   ?? throw new UserNotFoundException();

        user.Name = dto.Name;
        userRepository.Update(user);
        await unitOfWork.SaveAsync();
    }

    public async Task Delete(int userId)
    {
        var user = await userRepository.FindById(userId)
                   ?? throw new UserNotFoundException();

        userRepository.Delete(user);
        await unitOfWork.SaveAsync();
    }
}