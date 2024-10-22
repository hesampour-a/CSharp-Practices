using Shop.Entities.OrderItems;

namespace Shop.Entities.Products;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int AvailableCount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}