using Shop.Entities.Customers;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Services.Customers.Contracts;

public interface CustomersRepository
{
    Task CreateAsync(Customer newCustomer);
    Task<List<ShowCustomerDto>> GetAllAsync();
    Task<Customer> FindAsync(int id);

    Task<List<ShowOrderDto>> GetAllOrdersForCustomer(int id);
}