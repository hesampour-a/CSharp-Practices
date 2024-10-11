using Microsoft.AspNetCore.Mvc;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;

namespace Shop.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ProductsService productsService)
    : ControllerBase
{
    [HttpPost]
    public async Task<int> Create([FromBody] CreateProductDto productDto)
    {
        return await productsService.CreateAsync(productDto);
    }

    [HttpGet]
    public async Task<IEnumerable<ShowProductDto>> GetAll([FromQuery]string? search)
    {
        return await productsService.GetAllAsync(search);
    }

    [HttpPut("{id}")]
    public async Task Update([FromRoute] int id,
        [FromBody] EditProductDto productDto)
    {
        await productsService.UpdateAsync(id, productDto);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await productsService.RemoveAsync(id);
    }
}