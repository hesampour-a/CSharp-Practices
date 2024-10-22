using Shop.Entities.OrderItems;
using Shop.Persistence.Ef.Data;
using Shop.Services.OrderItems.Contracts;

namespace Shop.Persistence.Ef.OrderItems;

public class EfOrderItemsRepository(EfDataContext dbContext)
    : OrderItemsRepository
{
    public async Task AddRangeAsync(List<OrderItem> orderItems)
    {
        await dbContext.OrderItems.AddRangeAsync(orderItems);
    }
}