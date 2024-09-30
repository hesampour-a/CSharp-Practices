using OnlineShopManagement.Databases;
using OnlineShopManagement.Entities;


namespace OnlineShopManagement.Menues;
//var database = new Database();
public class MainMenu
{

    public Database database { get; set; } = new();


    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter Your Choice :");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Add Order");
            Console.WriteLine("4. Edit Order");
            Console.WriteLine("5. Remove Order");
            Console.WriteLine("6. Print All Orders");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    database.AddUser(Database.GetUserFromUser());
                    break;

                case "2":
                    database.AddProduct(Database.GetProductFromUser());
                    break;

                case "3":
                    var user = GetUserFromDatabaseById();
                    if (user == null)
                    {
                        Console.WriteLine("User Not Found!");
                        break;
                    }
                    var newOrder = user.AddOrder(database);
                    Console.WriteLine("Enter Count Of Order Items :");
                    int orderItemCount = int.Parse(Console.ReadLine()!);
                    database.PrintAllProducts();
                    for (int i = 0; i < orderItemCount; i++)
                    {
                        Console.WriteLine($"Order Item # {i + 1} :");
                        var newOrderItem = Database.GetOrderItemFromUser();
                        newOrderItem.OrderId = newOrder.Id;
                        database.AddOrderItem(newOrderItem);
                    }
                    break;

                case "4":
                    database.PrintAllOrders();
                    var order = GetOrderFromDatabase();
                    if (order == null)
                    {
                        Console.WriteLine("Order Not Found!");
                        break;
                    }
                    database.ShowAllOrderItemsForOrder(order);
                    EditOrderMenu.RunEditOrderMenu(database, order);

                    break;

                case "5":
                    database.PrintAllOrders();
                    var orderToRemove = GetOrderFromDatabase();
                    if (orderToRemove == null)
                    {
                        Console.WriteLine("Order Not Found");
                        break;
                    }
                    database.RemoveOrder(orderToRemove);

                    break;

                case "6":
                    database.PrintAllOrders();
                    break;
                case "7":
                    return;
                default:
                    break;
            }
            Console.WriteLine("Press Enter To Continue ...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    User? GetUserFromDatabaseById()
    {
        Console.WriteLine("Enter Your User ID :");
        return database.GetUserById(int.Parse(Console.ReadLine()!));

    }

    Order? GetOrderFromDatabase()
    {
        Console.WriteLine("Enter Order Id : ");
        return database.GetOrderById(int.Parse(Console.ReadLine()!));

    }

}