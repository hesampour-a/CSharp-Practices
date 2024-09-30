using OnlineShopManagement.Entities;

namespace OnlineShopManagement.Databases;

public class Database
{
    public List<User> Users { get; set; } = [
        new User{
                Id = 1,
                 Name = "Ali"
            },
        new User{
                Id = 2,
                Name = "Ehsan"
            },
        new User{
                Id = 3,
                Name = "Karim"
            }

    ];
    public List<Product> Products { get; set; } = [
        new Product{
            Id = 1,
            Price= 15000,
            Title="chips"
        },
         new Product{
            Id = 2,
            Price= 10000,
            Title="pofak"
        }, new Product{
            Id = 3,
            Price= 17000,
            Title="ice cream"
        },
    ];
    public List<Order> Orders { get; set; } = [];
    public List<OrderItem> OrderItems { get; set; } = [];


    public void AddUser(User user)
    {
        int newItemId = Users.Count > 0 ? Users.Last().Id + 1 : 1;
        user.Id = newItemId;
        Users.Add(user);
    }

    public void AddProduct(Product product)
    {
        int newItemId = Products.Count > 0 ? Products.Last().Id + 1 : 1;
        product.Id = newItemId;
        Products.Add(product);
    }

    public Order AddOrder(Order order)
    {
        int newItemId = Orders.Count > 0 ? Orders.Last().Id + 1 : 1;
        order.Id = newItemId;
        Orders.Add(order);
        return order;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        int newItemId = OrderItems.Count > 0 ? OrderItems.Last().Id + 1 : 1;
        orderItem.Id = newItemId;
        OrderItems.Add(orderItem);
    }

    public static User GetUserFromUser()
    {
        Console.WriteLine("Enter Your Name :");
        string userName = Console.ReadLine()!;

        return new User
        {
            Name = userName
        };
    }

    public static Product GetProductFromUser()
    {
        Console.WriteLine("Enter Product Title :");
        string productTitle = Console.ReadLine()!;
        Console.WriteLine("Enter Product Price :");
        double productPrice = double.Parse(Console.ReadLine()!);
        return new Product
        {
            Title = productTitle,
            Price = productPrice
        };
    }

    public static OrderItem GetOrderItemFromUser()
    {
        Console.WriteLine("Enter Product Id : ");
        int productId = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Product Count : ");
        int productCount = int.Parse(Console.ReadLine()!);
        return new OrderItem
        {
            ProductId = productId,
            ProductCount = productCount
        };

    }

    public User? GetUserById(int userId)
    {
        foreach (var user in Users)
        {
            if (user.Id == userId)
                return user;
        }
        return null;
    }

    public Order? GetOrderById(int orderId)
    {
        foreach (var order in Orders)
        {
            if (order.Id == orderId)
                return order;
        }
        return null;
    }

    List<OrderItem> GetAllOrderItemsForOrder(Order order)
    {
        var newOrderItems = new List<OrderItem>();

        foreach (var orderItem in OrderItems)
        {
            if (orderItem.OrderId == order.Id)
                newOrderItems.Add(orderItem);
        }
        return newOrderItems;
    }

    public void ShowAllOrderItemsForOrder(Order order)
    {
        var orderItems = GetAllOrderItemsForOrder(order);
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine($"Order Item ID : {orderItem.Id} Product ID : {orderItem.ProductId} Product Count : {orderItem.ProductCount}");
        }
    }
    public OrderItem? GetOrderItemById(int orderItemId)
    {
        foreach (var orderItem in OrderItems)
        {
            if (orderItem.Id == orderItemId)
                return orderItem;
        }
        return null;
    }

    public void RemoveOrderItem(OrderItem orderItem)
    {
        OrderItems.Remove(orderItem);
    }

    public void EditProductCountInOrderItem(int orderItemId, int newCount)
    {
        foreach (var orderItem in OrderItems)
        {
            if (orderItem.Id == orderItemId)
                orderItem.ProductCount = newCount;
        }
    }
    public void RemoveOrder(Order order)
    {
        Orders.Remove(order);
    }

    public Product? GetProductById(int productId)
    {
        foreach (var product in Products)
        {
            if (product.Id == productId)
                return product;
        }
        return null;
    }

    public void PrintAllOrders()
    {

        foreach (var order in Orders)
        {
            double totalPrice = 0;
            var user = GetUserById(order.Id);
            foreach (var orderItem in OrderItems)
            {
                if (order.Id == orderItem.OrderId)
                    totalPrice += GetProductById(orderItem.ProductId)!.Price * orderItem.ProductCount;
            }

            Console.WriteLine($"Order ID : {order.Id} * Customer Name : {user!.Name} * Total Price : {totalPrice}");
        }
    }
    public void PrintAllProducts()
    {
        foreach (var product in Products)
        {
            Console.WriteLine($"Product ID : {product.Id} * Product Title : {product.Title} * Product Price : {product.Price}");
        }
    }
}