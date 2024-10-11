using Shop.Services.OrderItems.Contracts.Dtos;

namespace Shop.Applications.Orders.AddOrders.Contracts.Dtos;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> OrderItemDtos { get; set; } = [];
}