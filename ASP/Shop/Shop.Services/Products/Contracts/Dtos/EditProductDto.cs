namespace Shop.Services.Products.Contracts.Dtos;

public class EditProductDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int AvailableCount { get; set; }
}