namespace Shop.ConsoleApp.Ef.Dtos.OrderItems;

public class ShowOrderItemDto
{
    public int OrderItemId { get; set; }
    public string ProductName { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductPrice { get; set; }
}