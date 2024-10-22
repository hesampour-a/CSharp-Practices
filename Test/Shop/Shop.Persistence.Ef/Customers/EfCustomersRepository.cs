using Microsoft.EntityFrameworkCore;
using Shop.Entities.Customers;
using Shop.Persistence.Ef.Data;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Persistence.Ef.Customers;

public class EfCustomersRepository(EfDataContext dbContext)
    : CustomersRepository
{
    public async Task CreateAsync(Customer newCustomer)
    {
        await dbContext.Customers.AddAsync(newCustomer);
    }

    public async Task<List<ShowCustomerDto>> GetAllAsync()
    {
        return await dbContext.Customers.Select(_ => new ShowCustomerDto
        {
            Id = _.Id,
            PhoneNumber = _.PhoneNumber,
            Name = _.Name
        }).ToListAsync();
    }

    public async Task<Customer> FindAsync(int id)
    {
        return await dbContext.Customers
            .FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<List<ShowOrderDto>> GetAllOrdersForCustomer(int id)
    {
        var customer = await dbContext.Set<Customer>().Where(_ => _.Id == id)
            .Include(_ => _.Orders).FirstOrDefaultAsync();
        return customer?.Orders.Select(_ => new ShowOrderDto
        {
            Id = _.Id,
            CustomerId = _.CustomerId,
        }).ToList();
    }
}