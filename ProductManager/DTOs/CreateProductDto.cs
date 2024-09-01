namespace ProductManager.DTOs;

public class CreateProductDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}