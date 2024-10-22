using Shop.Entities.OrderItems;
using Shop.Entities.Orders;
using Shop.Services.OrderItems.Contracts;
using Shop.Services.Orders.Contracts;
using Shop.Services.Orders.Contracts.Dtos;
using Shop.Services.Products.Contracts;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Services.Orders;

public class OrdersAppService(
    UnitOfWork unitOfWork,
    OrdersRepository ordersRepository,
    OrderItemsRepository orderItemsRepository,
    ProductsRepository productsRepository) : OrdersService
{
    public async Task<decimal> CreateAsync(int customerId,
        CreateOrderDto orderDto)
    {
        var newOrder = new Order
        {
            CustomerId = customerId
        };
        await ordersRepository.CreateAsync(newOrder);
        var orderItems = new List<OrderItem>();
        foreach (var orderItemDto in orderDto.OrderItemDtos)
            orderItems.Add(new OrderItem
            {
                Count = orderItemDto.Count,
                OrderId = newOrder.Id,
                ProductId = orderItemDto.ProductId
            });

        await orderItemsRepository.AddRangeAsync(orderItems);
        await unitOfWork.SaveAsync();

        decimal totalPrice = 0;

        foreach (var orderItem in orderItems)
            totalPrice += orderItem.Count *
                          await productsRepository.GetPriceById(orderItem
                              .ProductId);

        return newOrder.Id;
    }

    public async Task<IEnumerable<ShowAllOrdersDto>> GetAllAsync()
    {
        return await ordersRepository.GetAllAsync();
    }
}