using Shop.Applications.Orders.AddOrders.Contracts;
using Shop.Applications.Orders.AddOrders.Contracts.Dtos;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts;
using Shop.Services.Orders.Contracts.Dtos;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Applications.Orders.AddOrders;

public class AddOrderCommandHandler(
    UnitOfWork unitOfWork,
    OrdersService ordersService,
    CustomersService customersService) : AddOrderHandler
{
    public async Task<decimal> CreateAsync(CreateCustomerAndOrderDto orderDto)
    {
        try
        {
            await unitOfWork.BeginAsync();
            var customerId = await customersService.Create(
                new CreateCustomerDto
                {
                    Name = orderDto.Name,
                    PhoneNumber = orderDto.PhoneNumber
                });

            var totalPrice = await ordersService.CreateAsync(customerId,
                new CreateOrderDto
                {
                    OrderItemDtos = orderDto.OrderItemDtos
                });

            await unitOfWork.CommitAsync();

            return totalPrice;
        }
        catch (Exception e)
        {
            await unitOfWork.RoleBackAsync();
        }

        return 0;
    }
}