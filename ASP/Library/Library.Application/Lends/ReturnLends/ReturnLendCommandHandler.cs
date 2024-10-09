using Library.Application.Lends.ReturnLends.Contracts;
using Library.Services.Lends.Contracts;
using Library.Services.Lends.Contracts.Dtos;
using Library.Services.Rates.Contracts;
using Library.Services.Rates.Contracts.Dtos;
using Library.Services.UnitOfWorks;

namespace Library.Application.Lends.ReturnLends;

public class ReturnLendCommandHandler(
    LendsService lendsService,
    RatesService ratesService,
    LendRepository lendRepository,
    UnitOfWork unitOfWork) : ReturnLendHandler
{
    public async Task ReturnLendAsync(int id, ReturnLendDto lendDto)
    {
        try
        {
            await unitOfWork.Begin();

            await lendsService.ReturnLendAsync(id);

            if (lendDto.Score != null)
            {
                var lend = await lendRepository.GetByIdAsync(id);

                await ratesService.CreateAsync(new CreateRateDto
                {
                    BookId = lend.BookId,
                    Score = lendDto.Score!.Value
                });
            }

            await unitOfWork.Commit();
        }
        catch (Exception e)
        {
            await unitOfWork.Rollback();
        }
    }
}