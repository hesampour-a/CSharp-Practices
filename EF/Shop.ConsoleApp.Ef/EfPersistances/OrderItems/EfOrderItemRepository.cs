using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.OrderItems;

public class EfOrderItemRepository(EfDataContext dbContext)
{
    public void Create(OrderItem orderItem)
    {
        dbContext.OrderItems.Add(orderItem);
    }
    public OrderItem? GetById(int orderItemId)
    {
        return dbContext.OrderItems.FirstOrDefault(_=>_.Id == orderItemId);
    }
    public void DeleteRange(List<OrderItem> orderItems)
    {
        dbContext.OrderItems.RemoveRange(orderItems);
    }
}