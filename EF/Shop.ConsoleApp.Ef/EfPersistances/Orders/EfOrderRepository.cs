using Microsoft.EntityFrameworkCore;
using Shop.ConsoleApp.Ef.Dtos.OrderItems;
using Shop.ConsoleApp.Ef.Dtos.Orders;
using Shop.ConsoleApp.Ef.EfPersistances.OrderItems;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Orders;

public class EfOrderRepository(EfDataContext dbContext)
{
    EfOrderItemRepository orderItemRepository =
        new EfOrderItemRepository(dbContext);

    public void Create(Order order)
    {
        dbContext.Orders.Add(order);
    }

    public List<Order> GetCustomerOrders(int customerId)
    {
        return dbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .Include(_ => _.OrderItems)
            .ToList();
    }

    public List<OrderProductsDto> GetOrderProducts(int orderId)
    {
        return (from orderItem in dbContext.OrderItems
                where orderItem.OrderId == orderId
                join product in dbContext.Products
                    on orderItem.ProductId equals product.Id
                select new OrderProductsDto
                {
                    ProductCount = orderItem.ProductCount,
                    ProductPrice = product.Price
                }
            ).ToList();
    }

    public List<Order> GetOrdersForUser(int userId)
    {
        return dbContext.Orders.Where(o => o.CustomerId == userId).ToList();
    }

    public List<ShowOrderItemDto> ShowOrdersForUser(int orderId)
    {
        return (
            from order in dbContext.Orders
            where order.Id == orderId
            join orderItem in dbContext.OrderItems
                on order.Id equals orderItem.OrderId
            //     into oItem
            // from orderItem in oItem
            join product in dbContext.Products
                on orderItem.ProductId equals product.Id
            select new ShowOrderItemDto
            {
                OrderItemId = orderItem.Id,
                ProductName = product.Title,
                ProductCount = orderItem.ProductCount,
                ProductPrice = product.Price,
            }
        ).ToList();
    }

    public void DeleteRange(List<Order> orders)
    {
        List<OrderItem> customerOrderItems = [];
        orders.ForEach(o =>
        {
            dbContext.OrderItems.Where(_ => _.OrderId == o.Id).ToList()
                .AddRange(customerOrderItems);
        });
        orderItemRepository.DeleteRange(customerOrderItems);
        dbContext.Orders.RemoveRange(orders);
    }

    public Order? GetById(int orderId)
    {
        return dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
    }

    public void Delete(Order order)
    {
        List<OrderItem> customerOrderItems = dbContext.OrderItems
            .Where(_ => _.OrderId == order.Id).ToList();
        //orderItemRepository.DeleteRange(customerOrderItems);
        dbContext.Orders.Remove(order);
        dbContext.OrderItems.RemoveRange(order.OrderItems);
    }
}