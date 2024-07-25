using OnlineShopManagement.Databases;

namespace OnlineShopManagement.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];


    void AddOrderItem(OrderItem orderItem, Database database)
    {
        orderItem.OrderId = Id;
        database.AddOrderItem(orderItem);
    }
}