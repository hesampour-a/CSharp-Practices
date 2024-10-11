using Microsoft.AspNetCore.Mvc;
using Shop.Entities.Customers;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(
    CustomersService customersService) : ControllerBase
{
    [HttpPost]
    public async Task<int> Create([FromBody] CreateCustomerDto customerDto)
    {
        return await customersService.CreateAsync(customerDto);
    }

    [HttpGet]
    public async Task<IEnumerable<ShowCustomerDto>> GetAll()
    {
       return await customersService.GetAllAsync();
    }
    
    [HttpGet("{id}/Orders")]
    public async Task<IEnumerable<ShowOrderDto>> GetAllOrdersForUser([FromRoute] int id)
    {
        return await customersService.GetAllOrdersForUserAsync(id);
    }
}