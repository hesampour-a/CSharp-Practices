using Shop.Services.OrderItems.Contracts.Dtos;

namespace Shop.Services.Orders.Contracts.Dtos;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> OrderItemDtos { get; set; } = [];
}