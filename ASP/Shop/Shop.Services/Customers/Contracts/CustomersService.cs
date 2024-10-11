using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Services.Customers.Contracts;

public interface CustomersService
{
    Task<int> CreateAsync(CreateCustomerDto customerDto);
    Task<IEnumerable<ShowCustomerDto>> GetAllAsync();
    Task<IEnumerable<ShowOrderDto>> GetAllOrdersForUserAsync(int id);
}