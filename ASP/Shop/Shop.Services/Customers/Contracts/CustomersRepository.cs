using Shop.Entities.Customers;
using Shop.Services.Customers.Contracts.Dtos;

namespace Shop.Services.Customers.Contracts;

public interface CustomersRepository
{
    Task CreateAsync(Customer newCustomer);
    Task<IEnumerable<ShowCustomerDto>> GetAllAsync();
    Task<Customer> FindAsync(int id);
}