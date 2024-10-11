using Microsoft.AspNetCore.Mvc;
using Shop.Applications.Orders.AddOrders.Contracts;
using Shop.Applications.Orders.AddOrders.Contracts.Dtos;
using Shop.Entities.Orders;
using Shop.Services.Orders.Contracts;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(
    OrdersService ordersService,
    AddOrderHandler addOrderHandler) : ControllerBase
{
    [HttpPost("{customerId}")]
    public async Task<decimal> Create([FromRoute] int customerId,
        [FromBody] CreateOrderDto orderDto)
    {
        return await ordersService.CreateAsync(customerId, orderDto);
    }

    [HttpGet]
    public async Task<IEnumerable<ShowAllOrdersDto>> GetAll()
    {
        return await ordersService.GetAllAsync();
    }

    [HttpPost]
    public async Task<decimal> CreateCustomerAndOrder(
        [FromBody] CreateCustomerAndOrderDto orderDto)
    {
        return await addOrderHandler.CreateAsync(orderDto);
    }
}