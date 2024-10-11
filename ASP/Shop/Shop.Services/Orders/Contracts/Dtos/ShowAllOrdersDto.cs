using Shop.Services.OrderItems.Contracts.Dtos;

namespace Shop.Services.Orders.Contracts.Dtos;

public class ShowAllOrdersDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<ShowOrderItemDto> OrderItems { get; set; } = [];
}