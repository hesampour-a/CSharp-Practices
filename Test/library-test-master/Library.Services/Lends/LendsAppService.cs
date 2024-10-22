using Library.Entities.Lends;
using Library.Services.Books.Contracts;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Library.Services.Lends.Exceptions;
using Library.Services.Rates.Contracts;
using Library.Services.UnitOfWorks;
using Library.Services.Users.Contracts;

namespace Library.Services.Lends;

public class LendsAppService(
    UnitOfWork unitOfWork,
    LendRepository lendRepository,
    UserRepository userRepository,
    BookRepository bookRepository,
    RatesService ratesService) : LendsService
{
   

    public async Task<int> Create(CreateLendDto lendDto)
    {
        if (!await userRepository.CheckIfExistsByIdAsync(lendDto.UserId))
            throw new Exception("User not found");
        if (!await bookRepository.CheckIfExistsByIdAsync(lendDto.BookId))
            throw new Exception("Book not found");

        if (!await CheckIfUserCanLendNewBook(lendDto.UserId))
            throw new Exception("User is already in maximum number lends");

        var newLend = new Lend
        {
            UserId = lendDto.UserId,
            BookId = lendDto.BookId,
            LendDate = DateOnly.FromDateTime(DateTime.Today),
            ReturnDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(1)),
            IsReturned = false
        };
        await lendRepository.Create(newLend);
        await unitOfWork.SaveAsync();
        return newLend.Id;
    }

    public async Task ReturnLend(int id)
    {
        var lend = await lendRepository.Find(id)
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

   

    private async Task<bool> CheckIfUserCanLendNewBook(int userId)
    {
        var userValidLendCount =
            await userRepository.CalculateYearsHistoryAsync(userId) * 2;
        if (userValidLendCount == 0)
            userValidLendCount = 1;

        var currentLendsCount =
            await userRepository.CurrentLendsCountAsync(userId);

        if (currentLendsCount >= userValidLendCount)
            return false;

        return true;
    }
}