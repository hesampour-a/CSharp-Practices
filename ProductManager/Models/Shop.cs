
using ProductManager.DTOs;

namespace ProductManager.Models;

public class Shop
{
    private List<Product> _products = [];

    public void AddProduct(CreateProductDto dto)
    {
        _products.Add(new Product(dto.Title, dto.Price, dto.Count));
    }

    public List<ShowProductDto> ShowAllProducts()
    {
        return _products.Select((_, Index) => new ShowProductDto
        {
            Id = Index + 1,
            Title = _.Title,
            Price = _.Price,
            Count = _.Count
        }).ToList();
    }

    public void EditProduct(EditProductDto dto)
    {
        var product = _products[dto.Id - 1];
        product.Title = dto.Title;
        product.Price = dto.Price;
        product.Count = dto.Count;

    }

    public void DeleteProduct(DeleteProductDto dto)
    {
        _products.RemoveAt(dto.Id - 1);
    }

}