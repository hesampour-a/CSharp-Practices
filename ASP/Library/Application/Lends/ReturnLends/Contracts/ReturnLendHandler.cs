using Library.Services.Lends.Contracts.Dtos;

namespace Application.Lends.ReturnLends.Contracts;

public interface ReturnLendHandler
{
    Task ReturnLendAsync(int id, ReturnLendDto lendDto);
}