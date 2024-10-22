using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Services.Orders.Contracts;

public interface OrdersService
{
    Task<decimal> CreateAsync(int customerId, CreateOrderDto orderDto);
    Task<IEnumerable<ShowAllOrdersDto>> GetAllAsync();
}