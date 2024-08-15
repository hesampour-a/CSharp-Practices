using OnlineShopManagements.ConsoleApp.Interfaces;
using OnlineShppManagements.Models.Models.OnlineShopManagements;
using OnlineShppManagements.Models.Models.OrderItems;
using OnlineShppManagements.Models.Models.Orders;
using OnlineShppManagements.Models.Models.Products;

namespace OnlineShopManagements.ConsoleApp.Menus;

internal class GetOrderMenu(OnlineShopManagement shop, IUi ui, int userId) : IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();
    List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public void AddItemsToDictionary()
    {
        MenuItems.Add("Show Products", ShowProducts);
        MenuItems.Add("Add Order Item", AddOrderItem);
    }

    public void Show()
    {
        AddItemsToDictionary();
        new MenuBuilder(MenuItems, ui, "Back").Build();
        //if (Items.Count > 0)
        //    shop.Database.RegisterOrder(new Order(userId,Items));
        
    }
    public void ShowProducts()
    {
        shop.Database.Products.ForEach(_=> PrintProduct(_));
    }


    void PrintProduct(Product product)
    {
        ui.ShowMessage($"ID : {product.Id} , Title : {product.Title} , Price : {product.Price}");
    }

    void AddOrderItem()
    {
        var newOrderItem = new OrderItem(ui.GetInt("Enter product ID: "), ui.GetInt("Enter Product Count:"));
        if(Items.Any(_=>_.ProductId == newOrderItem.ProductId))
        {
            ui.ShowMessage("Product Alredy Exists in Order");
            return;
        }
        Items.Add(newOrderItem);
    }
}
