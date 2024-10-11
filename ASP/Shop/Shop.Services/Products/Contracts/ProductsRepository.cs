using Shop.Entities.Products;
using Shop.Services.Products.Contracts.Dtos;

namespace Shop.Services.Products.Contracts;

public interface ProductsRepository
{
    Task CreateAsync(Product newProduct);
    Task<IEnumerable<ShowProductDto>> GetAllAsync(string? search);
    Task<Product> FindByIdAsync(int id);
    void Remove(Product product);
    Task<decimal> GetPriceById(int orderItemProductId);
}