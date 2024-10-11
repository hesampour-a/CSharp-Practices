using Shop.Entities.OrderItems;
using Shop.Entities.Orders;

namespace Shop.Entities.Products;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int AvailableCount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}