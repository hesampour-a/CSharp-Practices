using Shop.Services.Products.Contracts.Dtos;

namespace Shop.Services.Products.Contracts;

public interface ProductsService
{
    Task<int> CreateAsync(CreateProductDto productDto);
    Task<IEnumerable<ShowProductDto>> GetAllAsync(string? search);
    Task UpdateAsync(int id, EditProductDto productDto);
    Task RemoveAsync(int id);
}