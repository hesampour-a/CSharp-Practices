using OnlineShopManagement.Databases;

namespace OnlineShopManagement.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;


    public Order AddOrder(Database database)
    {
        var newOrder = new Order
        {
            UserId = Id
        };
        return database.AddOrder(newOrder);
    }
}