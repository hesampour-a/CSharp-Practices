using Shop.Entities.OrderItems;

namespace Shop.Services.OrderItems.Contracts;

public interface OrderItemsRepository
{
    Task AddRangeAsync(List<OrderItem> orderItems);
}