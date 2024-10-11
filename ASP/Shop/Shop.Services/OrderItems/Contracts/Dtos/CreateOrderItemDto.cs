namespace Shop.Services.OrderItems.Contracts.Dtos;

public class CreateOrderItemDto
{
    public int ProductId { get; set; }
   
    public int Count { get; set; }
}