using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Services.Customers.Contracts;

public interface CustomersService
{
    Task<int> Create(CreateCustomerDto customerDto);
    Task<List<ShowCustomerDto>> GetAll();
    Task<List<ShowOrderDto>> GetAllOrdersForCustomer(int id);
}