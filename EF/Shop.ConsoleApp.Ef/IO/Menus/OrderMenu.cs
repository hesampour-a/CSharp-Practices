using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.Customers;
using Shop.ConsoleApp.Ef.EfPersistances.OrderItems;
using Shop.ConsoleApp.Ef.EfPersistances.Orders;
using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class OrderMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    private readonly EfCustomerRepository customerRepository = new(dbContext);

    private readonly EfOrderItemRepository orderItemRepository = new(dbContext);

    private readonly EfOrderRepository orderRepository = new(dbContext);

    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Create new Order", CreateNewOrder);
        MenuItems.Add("Show All Orders For User", ShowAllOrdersForUser);
        MenuItems.Add("Delete Order By Id", DeleteOrderById);
        MenuItems.Add("Edit Order Menu", ShowEditOrderMenu);
    }


    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui, "Back to Main Menu").Start();
    }

    private void ShowEditOrderMenu()
    {
        new EditOrderMenu(dbContext, ui).Show();
    }

    private void CreateNewOrder()
    {
        var customerId = ui.GetIntegerFromUser("Enter Customer Id :");
        var customer =
            customerRepository.GetById(customerId)
            ?? throw new NotFoundException(nameof(Customer), customerId);
        var order = new Order
        {
            CustomerId = customerId
        };
        orderRepository.Create(order);
        dbContext.SaveChanges();
        ShowAllProducts();
        var itemCount = ui.GetIntegerFromUser("Enter Number of Items :");
        for (var i = 0; i < itemCount; i++)
            orderItemRepository.Create(new OrderItem
            {
                ProductId = ui.GetIntegerFromUser("Enter Product Id :"),
                ProductCount = ui.GetIntegerFromUser("Enter Product Count :"),
                OrderId = order.Id
            });

        dbContext.SaveChanges();

        var orderProducts = orderRepository.GetOrderProducts(order.Id);
        decimal totalPrice = 0;
        orderProducts.ForEach(_ =>
        {
            totalPrice += _.ProductPrice * _.ProductCount;
        });
        order.TotalPrice = totalPrice;
        dbContext.SaveChanges();
    }

    private void ShowAllOrdersForUser()
    {
        var customerId = ui.GetIntegerFromUser("Enter Customer Id :");
        var orders = orderRepository.GetCustomerOrders(customerId);

        orders.ForEach(_ =>
        {
            ui.ShowMessage($"Order Id : {_.Id},Total Price{_.TotalPrice}");
        });
    }

    private void DeleteOrderById()
    {
        var orderId = ui.GetIntegerFromUser("Enter Order Id :");
        var order = orderRepository.GetById(orderId)
                    ?? throw new NotFoundException(nameof(Order), orderId);
        orderRepository.Delete(order);
        dbContext.SaveChanges();
    }

    private void ShowAllProducts()
    {
        var products = dbContext.Products.ToList();
        products.ForEach(product => { PrintProduct(product); });
    }

    private void PrintProduct(Product product)
    {
        ui.ShowMessage(
            $"Id : {product.Id} , Name : {product.Title} , Price : {product.Price} ");
    }
}