using Microsoft.AspNetCore.Mvc;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;

namespace Shop.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ProductService productService)
    : ControllerBase
{
    [HttpPost]
    public async Task<int> Create([FromBody] CreateProductDto productDto)
    {
        return await productService.Create(productDto);
    }

    [HttpGet]
    public async Task<IEnumerable<ShowProductDto>> GetAll(
        [FromQuery] string? search)
    {
        return await productService.GetAll(search);
    }

    [HttpPut("{id}")]
    public async Task Update([FromRoute] int id,
        [FromBody] EditProductDto productDto)
    {
        await productService.Update(id, productDto);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await productService.Remove(id);
    }
}