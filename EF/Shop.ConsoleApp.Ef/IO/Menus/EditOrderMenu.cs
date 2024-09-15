using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.OrderItems;
using Shop.ConsoleApp.Ef.EfPersistances.Orders;
using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class EditOrderMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    private readonly EfOrderItemRepository orderItemRepository = new(dbContext);

    private readonly EfOrderRepository orderRepository = new(dbContext);

    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Add Item to Order", AddItemToOrder);
        MenuItems.Add("Remove Item From Order", RemoveItemFromOrder);
        MenuItems.Add("Change number of products", ChangeItemCountToOrder);
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui, "Back to Order Menu").Start();
    }

    private void ChangeItemCountToOrder()
    {
        ShowAllOrderItemsForOrder();
        var orderItemId = ui.GetIntegerFromUser("Enter an order item ID: ");
        var newOrderItemCount =
            ui.GetIntegerFromUser("Enter an order item count: ");
        var orderItem =
            orderItemRepository.GetById(orderItemId)
            ?? throw new NotFoundException(nameof(OrderItem), orderItemId);
        orderItem.ProductCount = newOrderItemCount;
        dbContext.SaveChanges();
    }

    private void RemoveItemFromOrder()
    {
        ShowAllOrderItemsForOrder();
        var orderItemId = ui.GetIntegerFromUser("Enter an order item ID: ");
        var orderItem =
            dbContext.OrderItems.FirstOrDefault(_ => _.Id == orderItemId)
            ?? throw new NotFoundException(nameof(OrderItem), orderItemId);
        dbContext.OrderItems.Remove(orderItem);
        dbContext.SaveChanges();
    }

    private void AddItemToOrder()
    {
        ShowAllOrdersForUser();
        var orderId = ui.GetIntegerFromUser("Enter an order ID: ");
        var orderItem = new OrderItem
        {
            OrderId = orderId,
            ProductCount = ui.GetIntegerFromUser("Enter product count: "),
            ProductId = ui.GetIntegerFromUser("Enter product ID: ")
        };
        orderItemRepository.Create(orderItem);
        dbContext.SaveChanges();
    }

    public void ShowAllOrderItemsForOrder()
    {
        ShowAllOrdersForUser();
        var orderId = ui.GetIntegerFromUser("Enter an order ID: ");
        var orderItems = orderRepository.ShowOrdersForUser(orderId);
        orderItems.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id : '{_.OrderItemId}' - " +
                $"Product Name : '{_.ProductName}' - " +
                $"Price : '{_.ProductPrice}' - " +
                $"Quantity : '{_.ProductCount}'");
        });
    }

    private void ShowAllOrdersForUser()
    {
        var customerId = ui.GetIntegerFromUser("Enter Customer Id :");
        var orders = orderRepository.GetOrdersForUser(customerId);

        orders.ForEach(_ =>
        {
            ui.ShowMessage($"Order Id : {_.Id},Total Price{_.TotalPrice}");
        });
    }
}