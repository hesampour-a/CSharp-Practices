using Shop.Entities.Customers;
using Shop.Entities.OrderItems;

namespace Shop.Entities.Orders;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}