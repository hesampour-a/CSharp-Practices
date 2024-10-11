using Microsoft.EntityFrameworkCore;
using Shop.Entities.Customers;
using Shop.Persistence.Ef.Data;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;

namespace Shop.Persistence.Ef.Customers;

public class EfCustomersRepository(EfDataContext dbContext)
    : CustomersRepository
{
    public async Task CreateAsync(Customer newCustomer)
    {
        await dbContext.Customers.AddAsync(newCustomer);
    }

    public async Task<IEnumerable<ShowCustomerDto>> GetAllAsync()
    {
        return await dbContext.Customers.Select(_ => new ShowCustomerDto
        {
            Id = _.Id,
            PhoneNumber = _.PhoneNumber,
            Name = _.Name,
        }).ToListAsync();
    }

    public async Task<Customer> FindAsync(int id)
    {
        return await dbContext.Customers.Include(_ => _.Orders)
            .FirstOrDefaultAsync(_ => _.Id == id);
    }
}