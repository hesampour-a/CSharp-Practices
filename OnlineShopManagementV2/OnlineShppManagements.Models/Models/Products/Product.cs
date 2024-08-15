using OnlineShppManagements.Models.Interfaces;

namespace OnlineShppManagements.Models.Models.Products;

public class Product(string title, double price) : IHasId
{
    public int Id { get; set; }
    public string Title { get; init; } = title;
    public double Price { get; init; } = price;


}
