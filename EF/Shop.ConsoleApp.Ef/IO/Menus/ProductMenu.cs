using Shop.ConsoleApp.Ef.Dtos.Products;
using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.Products;
using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class ProductMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    private readonly EfProductRepository productRepository = new(dbContext);
    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Create New Product", CreateProduct);
        MenuItems.Add("Show All Products", ShowAllProducts);
        MenuItems.Add("Edit Product", EditProduct);
        MenuItems.Add("Delete Product", DeleteProduct);
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui, "Back to Main Menu").Start();
    }

    private void CreateProduct()
    {
        var newProduct = new Product
        {
            Title = ui.GetStringFromUser("Enter Product Name: "),
            Price = ui.GetDecimalFromUser("Enter Product Price: ")
        };

        productRepository.Add(newProduct);
        dbContext.SaveChanges();
    }

    private void ShowAllProducts()
    {
        var products = productRepository.GetProducts();
        products.ForEach(product => { PrintProduct(product); });
    }


    private void EditProduct()
    {
        var id = ui.GetIntegerFromUser("Enter Product Id: ");
        var product = dbContext.Products.FirstOrDefault(_ => _.Id == id)
                      ?? throw new NotFoundException(nameof(Product), id);
        product.Title = ui.GetStringFromUser("Enter Products new Title: ");
        product.Price = ui.GetDecimalFromUser("Enter Products new Price: ");
        dbContext.SaveChanges();
    }

    private void DeleteProduct()
    {
        var id = ui.GetIntegerFromUser("Enter Product Id: ");
        var product = productRepository.GetById(id)
                      ?? throw new NotFoundException(nameof(Product), id);
        productRepository.Delete(product);
        dbContext.SaveChanges();
    }

    private void PrintProduct(ShowProductDto product)
    {
        ui.ShowMessage(
            $"Id : {product.Id} , Name : {product.Title} , Price : {product.Price} ");
    }
}