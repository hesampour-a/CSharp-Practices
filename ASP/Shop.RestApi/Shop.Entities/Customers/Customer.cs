using Shop.Entities.Orders;

namespace Shop.Entities.Customers;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = [];
}