using Shop.Services.OrderItems.Contracts.Dtos;

namespace Shop.Applications.Orders.AddOrders.Contracts.Dtos;

public class CreateCustomerAndOrderDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public List<CreateOrderItemDto> OrderItemDtos { get; set; } = [];
}