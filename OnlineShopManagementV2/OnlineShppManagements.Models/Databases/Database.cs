using OnlineShppManagements.Models.Interfaces;
using OnlineShppManagements.Models.Models.Orders;
using OnlineShppManagements.Models.Models.Products;
using OnlineShppManagements.Models.Models.Users;

namespace OnlineShppManagements.Models.Databases;

public class Database
{
    public List<Product> Products { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
    public List<User> Users { get; set; } = [];

    public void RegisterProduct(Product product)
    {
        product.Id = CalculateNewItemId(Products);
        Products.Add(product);
    }
    public void RegisterOrder(Order order)
    {
        order.Id = CalculateNewItemId(Orders);
        Orders.Add(order);
    }

    public void RegisterUser(User user)
    {
        user.Id = CalculateNewItemId(Users);
        Users.Add(user);
    }


    int CalculateNewItemId<T>(List<T> items) where T : IHasId
      => items.Count > 0 ? items.Last().Id + 1 : 1;

}
