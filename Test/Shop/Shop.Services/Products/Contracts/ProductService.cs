using Shop.Services.Products.Contracts.Dtos;

namespace Shop.Services.Products.Contracts;

public interface ProductService
{
    Task<int> Create(CreateProductDto productDto);
    Task<IEnumerable<ShowProductDto>> GetAll(string? search = null);
    Task Update(int productId, EditProductDto productDto);
    Task Remove(int id);
}