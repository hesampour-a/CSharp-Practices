using Microsoft.EntityFrameworkCore;
using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.Products;
using Shop.ConsoleApp.Ef.IO.Interfaces;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    EfProductRepository productRepository = new EfProductRepository(dbContext);
    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Product Menu", ShowProductMenu);
        MenuItems.Add("Personnel Menu", ShowPersonnelMenu);
        MenuItems.Add("Customer Menu", ShowCustomerMenu);
        MenuItems.Add("Order Menu", ShowOrderMenu);
        MenuItems.Add("CustomerOrderRecord", ShowCustomerOrderRecord);
        MenuItems.Add("ProductsReport", ShowProductsReport);
    }

    void ShowCustomerOrderRecord()
    {
        new EditOrderMenu(dbContext, ui).ShowAllOrderItemsForOrder();
    }

    void ShowProductsReport()
    {
        var products = productRepository.GetProductsReport();

        products.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id}" +
                $" - Title: {_.Title}" +
                $" - Sold Quantity: {_.SoldQuantity}" +
                $" - Sell Number : {_.Count}");
        });
    }


    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui).Start();
    }

    void ShowProductMenu()
    {
        new ProductMenu(dbContext, ui).Show();
    }

    void ShowPersonnelMenu()
    {
        new PersonnelMenu(dbContext, ui).Show();
    }

    void ShowCustomerMenu()
    {
        new CustomerMenu(dbContext, ui).Show();
    }

    void ShowOrderMenu()
    {
        new OrderMenu(dbContext, ui).Show();
    }
}