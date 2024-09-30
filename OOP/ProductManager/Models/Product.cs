namespace ProductManager.Models;

public class Product(string title, decimal price, int count)
{
    public string Title { get; set; } = title;
    public decimal Price { get; set; } = price;
    public int Count { get; set; } = count;
}