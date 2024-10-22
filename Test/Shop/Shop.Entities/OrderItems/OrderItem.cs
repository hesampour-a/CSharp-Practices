using Shop.Entities.Orders;
using Shop.Entities.Products;

namespace Shop.Entities.OrderItems;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
}