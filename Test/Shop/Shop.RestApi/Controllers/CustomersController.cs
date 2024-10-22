using Microsoft.AspNetCore.Mvc;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(
    CustomersService customersService) : ControllerBase
{
    [HttpPost]
    public async Task<int> Create([FromBody] CreateCustomerDto customerDto)
    {
        return await customersService.Create(customerDto);
    }

    [HttpGet]
    public async Task<IEnumerable<ShowCustomerDto>> GetAll()
    {
        return await customersService.GetAll();
    }

    [HttpGet("{id}/Orders")]
    public async Task<IEnumerable<ShowOrderDto>> GetAllOrdersForUser(
        [FromRoute] int id)
    {
        return await customersService.GetAllOrdersForCustomer(id);
    }
}