using OnlineShppManagements.Models.Databases;
using OnlineShppManagements.Models.Mapper;
using OnlineShppManagements.Models.Models.OrderItems;
using OnlineShppManagements.Models.Models.Orders;

namespace OnlineShppManagements.Models.Models.OnlineShopManagements;

public class OnlineShopManagement
{
    public Database Database { get; set; } = new Database();
    public List<OrderDto> GetAllOrders()
    {
        return Database.Orders.Select(
            _ => _.CreateOrderDto(Database.Products, Database.Users))
            .ToList();
    }
    public void AddOrderItemToOrder(int orderId, OrderItem orderItem)
    {
        Database.Orders.Find(_ => _.Id == orderId)!.OrderItems.Add(orderItem);
    }
    public void RemoveOrderItemFromOrder(int orderId, int productId)
    {
        Database.Orders.Find(_ => _.Id == orderId)!.OrderItems.Remove(Database.Orders.Find(_ => _.Id == orderId)!.OrderItems.Find(_ => _.ProductId == productId)!);
    }
    public void ChangeNumberOfOrderItem(int orderId, int productId, int count)
    {
        Database.Orders.Find(_ => _.Id == orderId)!.OrderItems.Find(_ => _.ProductId == productId)!.Count = count;
    }
    public OrderDto FindOrderById(int id)
    {
        var order = Database.Orders.Find(_ => _.Id == id)
            ?? throw new Exception($"Order by  Id {id} not found");
        return order.CreateOrderDto(Database.Products, Database.Users);
    }

    public List<OrderDto> FindOrdersForUser(int userId)
    {
        var orders = Database.Orders.Where(o => o.UserId == userId).ToList();
        return orders.Select(_ => _.CreateOrderDto(Database.Products, Database.Users)).ToList();
    }

    public void RemoveOrderById(int orderId)
    {
        var order = Database.Orders.Find(_ => _.Id == orderId)
            ?? throw new Exception($"Order with ID {orderId} not found");

        Database.Orders.Remove(order);
    }

}
