using Shop.Entities.Customers;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Services.Customers;

public class CustomersAppService(
    UnitOfWork unitOfWork,
    CustomersRepository customersRepository) : CustomersService
{
    public async Task<int> CreateAsync(CreateCustomerDto customerDto)
    {
        var newCustomer = new Customer
        {
            Name = customerDto.Name,
            PhoneNumber = customerDto.PhoneNumber,
        };
        await customersRepository.CreateAsync(newCustomer);
        await unitOfWork.SaveAsync();
        return newCustomer.Id;
    }

    public async Task<IEnumerable<ShowCustomerDto>> GetAllAsync()
    {
        return await customersRepository.GetAllAsync();
    }

    public async Task<IEnumerable<ShowOrderDto>>
        GetAllOrdersForUserAsync(int id)
    {
        var user = await customersRepository.FindAsync(id)
                   ?? throw new Exception("Customer not found");

        return user.Orders.Select(_ => new ShowOrderDto
        {
            Id = _.Id,
            CustomerId = _.CustomerId,
        });
    }
}