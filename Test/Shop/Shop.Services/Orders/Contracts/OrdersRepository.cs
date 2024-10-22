using Shop.Entities.Orders;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Services.Orders.Contracts;

public interface OrdersRepository
{
    Task CreateAsync(Order newOrder);
    Task<IEnumerable<ShowAllOrdersDto>> GetAllAsync();
}