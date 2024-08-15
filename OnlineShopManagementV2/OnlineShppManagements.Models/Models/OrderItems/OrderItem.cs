namespace OnlineShppManagements.Models.Models.OrderItems;

public class OrderItem(int productId, int count)
{
    public int ProductId { get; set; } = productId;
    public int Count { get; set; } = count;
}
