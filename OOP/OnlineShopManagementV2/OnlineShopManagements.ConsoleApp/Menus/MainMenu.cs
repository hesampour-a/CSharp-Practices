using OnlineShopManagements.ConsoleApp.Interfaces;
using OnlineShppManagements.Models.Models.OnlineShopManagements;
using OnlineShppManagements.Models.Models.Products;
using OnlineShppManagements.Models.Models.Users;

namespace OnlineShopManagements.ConsoleApp.Menus;

internal class MainMenu(OnlineShopManagement shop,IUi ui) : IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();

    public void AddItemsToDictionary()
    {
        MenuItems.Add("Add User",GetUser);
        MenuItems.Add("Add Product",GetProduct);
        MenuItems.Add("Add Order",ShowGetOrderMenu);
    }
    void GetUser()
    {
        var newUser = new User(ui.GetString("Enter User Name:"));
        shop.Database.RegisterUser(newUser);
    }
    void GetProduct()
    {
        var newProduct = new Product(ui.GetString("Enter product title:"),ui.GetDouble("Enter product price:"));
        shop.Database.RegisterProduct(newProduct);
    }
    void ShowGetOrderMenu()
    {
       new GetOrderMenu(shop,ui,ui.GetInt("Enter your ID:")).Show();
    }

    public void Show()
    {
        AddItemsToDictionary();
        new MenuBuilder(MenuItems,ui).Build();
    }
}
