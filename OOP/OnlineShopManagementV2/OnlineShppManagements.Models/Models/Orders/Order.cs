using OnlineShppManagements.Models.Interfaces;
using OnlineShppManagements.Models.Models.OrderItems;

namespace OnlineShppManagements.Models.Models.Orders;

public class Order(int userId, List<OrderItem> orderItems) : IHasId
{
    public int Id { get; set; }
    public int UserId { get; init; } = userId;
    public List<OrderItem> OrderItems { get; set; } =orderItems;
}
