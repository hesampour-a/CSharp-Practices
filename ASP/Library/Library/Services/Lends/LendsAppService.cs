using Library.Dtos.Lends;
using Library.EfPersistence.UnitOfWorks;
using Library.Entities.Lends;
using Library.Repositories.Books;
using Library.Repositories.Lends;
using Library.Repositories.Users;

namespace Library.Services.Lends;

public class LendsAppService(
    UnitOfWork unitOfWork,
    LendRepository lendRepository,
    UserRepository userRepository,
    BookRepository bookRepository) : LendsService
{
    public async Task<ShowLendDto> GetByIdAsync(int id)
    {
        var lend = await lendRepository.GetByIdAsync(id)
                   ?? throw new Exception("Lend not found");
        return new ShowLendDto
        {
            Id = lend.Id,
            BookId = lend.BookId,
            LendDate = lend.LendDate,
            ReturnDate = lend.ReturnDate,
            UserId = lend.UserId,
        };
    }

    public async Task<IEnumerable<ShowLendDto>> GetAllAsync(int? bookId,
        int? userId)
    {
        return await lendRepository.GetAllAsync(bookId, userId);
    }

    public async Task<int> CreateAsync(CreateLendDto lendDto)
    {
        if (!await userRepository.CheckIfExistsByIdAsync(lendDto.UserId))
            throw new Exception("User not found");
        if (!await bookRepository.CheckIfExistsByIdAsync(lendDto.BookId))
            throw new Exception("Book not found");

        int userValidLendCount =
            await userRepository.CalculateYearsHistoryAsync(lendDto.UserId) * 2;

        int currentLendsCount =
            await userRepository.CurrentLendsCountAsync(lendDto.UserId);

        if (currentLendsCount >= userValidLendCount)
            throw new Exception("User is already in maximum number lends");
        var newLend = new Lend
        {
            UserId = lendDto.UserId,
            BookId = lendDto.BookId,
            LendDate = DateOnly.FromDateTime(DateTime.Today),
            ReturnDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(1)),
            IsReturned = false,
        };
        await lendRepository.CreateAsync(newLend);
        await unitOfWork.SaveAsync();
        return newLend.Id;
    }

    public async Task ReturnLendAsync(int id)
    {
        var lend = await lendRepository.GetByIdAsync(id)
                   ?? throw new Exception("Lend not found");

        if (lend.ReturnDate < DateOnly.FromDateTime(DateTime.Today))
        {
            var penaltyAmpount =
                DateTime.Today.Day - lend.ReturnDate.Day * 20000;
            throw new Exception($"you should pay {penaltyAmpount}");
        }

        lend.IsReturned = true;
        await unitOfWork.SaveAsync();
    }
}