namespace Shop.Services.OrderItems.Contracts.Dtos;

public class ShowOrderItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
}