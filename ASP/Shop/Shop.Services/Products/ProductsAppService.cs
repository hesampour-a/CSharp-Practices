using Shop.Entities.Products;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Services.Products;

public class ProductsAppService(
    UnitOfWork unitOfWork,
    ProductsRepository productsRepository) : ProductsService
{
    public async Task<int> CreateAsync(CreateProductDto productDto)
    {
        var newProduct = new Product
        {
            Price = productDto.Price,
            Title = productDto.Title,
            AvailableCount = productDto.AvailableCount,
        };
        await productsRepository.CreateAsync(newProduct);
        await unitOfWork.SaveAsync();
        return newProduct.Id;
    }

    public async Task<IEnumerable<ShowProductDto>> GetAllAsync(string? search)
    {
        return await productsRepository.GetAllAsync(search);
    }

    public async Task UpdateAsync(int id, EditProductDto productDto)
    {
        var product = await productsRepository.FindByIdAsync(id)
                      ?? throw new Exception(
                          $"Product with id: {id} not found");
        product.Title = productDto.Title;
        product.Price = productDto.Price;
        product.AvailableCount = productDto.AvailableCount;
        await unitOfWork.SaveAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var product = await productsRepository.FindByIdAsync(id)
                      ?? throw new Exception(
                          $"Product with id: {id} not found");
        productsRepository.Remove(product);
        await unitOfWork.SaveAsync();
    }
}