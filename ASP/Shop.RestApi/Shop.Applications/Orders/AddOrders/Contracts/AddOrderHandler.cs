using Shop.Applications.Orders.AddOrders.Contracts.Dtos;

namespace Shop.Applications.Orders.AddOrders.Contracts;

public interface AddOrderHandler
{
    Task<decimal> CreateAsync(CreateCustomerAndOrderDto orderDto);
}