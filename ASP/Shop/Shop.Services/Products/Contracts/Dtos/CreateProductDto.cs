namespace Shop.Services.Products.Contracts.Dtos;

public class CreateProductDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int AvailableCount { get; set; }
}