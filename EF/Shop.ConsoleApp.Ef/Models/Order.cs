namespace Shop.ConsoleApp.Ef.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
}