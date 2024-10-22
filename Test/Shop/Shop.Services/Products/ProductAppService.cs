using Shop.Entities.Products;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;
using Shop.Services.Products.Exceptions;
using Shop.Services.UnitOfWorks.Contracts;

namespace Shop.Services.Products;

public class ProductAppService(
    UnitOfWork unitOfWork,
    ProductsRepository productsRepository) : ProductService
{
    public async Task<int> Create(CreateProductDto productDto)
    {
        var newProduct = new Product
        {
            Price = productDto.Price,
            Title = productDto.Title,
            AvailableCount = productDto.AvailableCount
        };
        await productsRepository.CreateAsync(newProduct);
        await unitOfWork.SaveAsync();
        return newProduct.Id;
    }

    public async Task<IEnumerable<ShowProductDto>> GetAll(string? search)
    {
        return await productsRepository.GetAllAsync(search);
    }

    public async Task Update(int productId, EditProductDto productDto)
    {
        var product = await productsRepository.FindByIdAsync(productId)
                      ?? throw new ProductNotFoundException();
        product.Title = productDto.Title;
        product.Price = productDto.Price;
        product.AvailableCount = productDto.AvailableCount;
        await unitOfWork.SaveAsync();
    }

    public async Task Remove(int id)
    {
        var product = await productsRepository.FindByIdAsync(id)
                      ?? throw new ProductNotFoundException();
        productsRepository.Remove(product);
        await unitOfWork.SaveAsync();
    }
}