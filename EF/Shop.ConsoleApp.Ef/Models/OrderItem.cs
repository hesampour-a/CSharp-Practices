namespace Shop.ConsoleApp.Ef.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int? OrderId { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }
    public Order? Order { get; set; }
}