// using OnlineShopManagement.Databases;

// var database = new Database();

// Run();

// void Run()
// {
//     while (true)
//     {
//         Console.WriteLine("Enter Your Choice :");
//         Console.WriteLine("1. Add User");
//         Console.WriteLine("2. Add Product");
//         Console.WriteLine("3. Add Order");
//         Console.WriteLine("4. Edit Order");
//         Console.WriteLine("5. Remove Order");
//         string choice = Console.ReadLine()!;

//         switch (choice)
//         {
//             case "1":
//                 database.AddUser(Database.GetUserFromUser());
//                 break;

//             case "2":
//                 database.AddProduct(Database.GetProductFromUser());
//                 break;

//             case "3":
//                 Console.WriteLine("Enter Your User ID :");
//                 int userId = int.Parse(Console.ReadLine()!);
//                 var user = database.GetUserById(userId);
//                 if (user == null)
//                 {
//                     Console.WriteLine("User Not Found!");
//                     break;
//                 }
//                 var newOrder = user.AddOrder(database);
//                 Console.WriteLine("Enter Count Of Order Items :");
//                 int orderItemCount = int.Parse(Console.ReadLine()!);
//                 for (int i = 0; i < orderItemCount; i++)
//                 {
//                     Console.WriteLine($"Order Item # {i} :");
//                     var newOrderItem = Database.GetOrderItemFromUser();
//                     newOrderItem.OrderId = newOrder.Id;
//                     database.AddOrderItem(newOrderItem);
//                 }
//                 break;

//             case "4":
//                 Console.WriteLine("Enter Order Id : ");
//                 var order = database.GetOrderById(int.Parse(Console.ReadLine()!));
//                 if (order == null)
//                 {
//                     Console.WriteLine("Order Not Found!");
//                     break;
//                 }
//                 database.ShowAllOrderItemsForOrder(order);

//                 Console.WriteLine("Select Your Choice :");
//                 Console.WriteLine("1. Add New Product To Order :");
//                 Console.WriteLine("2. Remove Product From Order :");
//                 Console.WriteLine("3. Change Product Count :");

//                 switch (Console.ReadLine()!)
//                 {
//                     case "1":
//                         var newOrderItem = Database.GetOrderItemFromUser();
//                         newOrderItem.OrderId = order.Id;
//                         database.AddOrderItem(newOrderItem);
//                         break;
//                     case "2":
//                         Console.WriteLine("Enter OrderItem ID : ");
//                         var orderItemFetchedById = database.GetOrderItemById(int.Parse(Console.ReadLine()!));
//                         if (orderItemFetchedById == null)
//                         {
//                             Console.WriteLine("Order Item Not Found!");
//                             break;
//                         }
//                         database.RemoveOrderItem(orderItemFetchedById);
//                         break;
//                     case "3":
//                         Console.WriteLine("Enter Order Item Id : ");
//                         int orItemId = int.Parse(Console.ReadLine()!);
//                         Console.WriteLine("Enter New Product Count : ");
//                         int orItemCount = int.Parse(Console.ReadLine()!);
//                         database.EditProductCountInOrderItem(orItemId, orItemCount);
//                         break;

//                     default:
//                         break;
//                 }

//                 break;
//             default:
//                 break;
//         }
//     }
// }


using OnlineShopManagement.Menues;

var mainMenu = new MainMenu();
mainMenu.Run();