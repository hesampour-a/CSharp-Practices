namespace OnlineShppManagements.Models.Models.Orders;

public class OrderDto
{
    public int OrderId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public double TotalPrice { get; set; }
}
