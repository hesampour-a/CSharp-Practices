using OnlineShopManagement.Databases;
using OnlineShopManagement.Entities;

namespace OnlineShopManagement.Menues;

public class EditOrderMenu
{
    public static void RunEditOrderMenu(Database database, Order order)
    {
        Console.WriteLine("Select Your Choice :");
        Console.WriteLine("1. Add New Product To Order :");
        Console.WriteLine("2. Remove Product From Order :");
        Console.WriteLine("3. Change Product Count :");

        switch (Console.ReadLine()!)
        {
            case "1":
                var newOrderItem = Database.GetOrderItemFromUser();
                newOrderItem.OrderId = order.Id;
                database.AddOrderItem(newOrderItem);
                break;
            case "2":
                Console.WriteLine("Enter OrderItem ID : ");
                var orderItemFetchedById = database.GetOrderItemById(int.Parse(Console.ReadLine()!));
                if (orderItemFetchedById == null)
                {
                    Console.WriteLine("Order Item Not Found!");
                    break;
                }
                database.RemoveOrderItem(orderItemFetchedById);
                break;
            case "3":
                Console.WriteLine("Enter Order Item Id : ");
                int orItemId = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter New Product Count : ");
                int orItemCount = int.Parse(Console.ReadLine()!);
                database.EditProductCountInOrderItem(orItemId, orItemCount);
                break;

            default:
                break;
        }
    }
}