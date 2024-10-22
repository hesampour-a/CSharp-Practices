using Library.Services.Lends.Contracts.Dtos;

namespace Library.Services.Lends.Contracts;

public interface LendsService
{
    
    Task<int> Create(CreateLendDto lendDto);
    Task ReturnLend(int id);

   
}