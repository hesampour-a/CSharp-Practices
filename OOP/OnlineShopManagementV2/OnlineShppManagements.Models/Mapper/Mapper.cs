using OnlineShppManagements.Models.Models.OrderItems;
using OnlineShppManagements.Models.Models.Orders;
using OnlineShppManagements.Models.Models.Products;
using OnlineShppManagements.Models.Models.Users;

namespace OnlineShppManagements.Models.Mapper;

public static class Mapper
{
    public static OrderDto CreateOrderDto(this Order order, List<Product> products, List<User> users)
    {
        double price = 0;
        order.OrderItems.ForEach(orderItem =>
        {
            price += orderItem.Count * products.Find(_ => _.Id == orderItem.ProductId)!.Price;
        });
        return new OrderDto
        {
            OrderId = order.Id,
            UserName = users.Find(_ => _.Id == order.UserId)!.Name,
            TotalPrice = price

        };
    }


}
