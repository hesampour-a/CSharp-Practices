using ProductManager.DTOs;
using ProductManager.Models;

namespace ProductManager.Ui;

public class MainMenu(Shop shop)
{
    void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Register new product");
        Console.WriteLine("2. Show All products");
        Console.WriteLine("3. Edit Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("0. Exit");
    }

    int GetUserChoice()
    {
        Console.WriteLine("Enter your choice");

        int userChoice = 0;
        bool isChoiceValid = false;
        while (!isChoiceValid)
        {
            isChoiceValid = int.TryParse(Console.ReadLine(), out int result);
            if (!isChoiceValid)
            {
                Console.WriteLine("Enter a valid number");
            }
            if (result > 4 || result < 0 || !isChoiceValid)
            {
                isChoiceValid = false;
                Console.WriteLine("Enter a valid choice");
            }
            if (isChoiceValid)
            {
                userChoice = result;
            }
        }
        return userChoice;
    }

    void AddProduct()
    {
        Console.WriteLine("Enter product title");
        string title = Console.ReadLine();
        if (title == "0")
            return;
        Console.WriteLine("Enter product price");
        decimal price = decimal.Parse(Console.ReadLine());
        if (price == 0)
            return;
        Console.WriteLine("Enter product count");
        int count = int.Parse(Console.ReadLine());
        if (count == 0)
            return;

        shop.AddProduct(new CreateProductDto
        {
            Title = title,
            Count = count,
            Price = price
        });
    }
    void ShowAllProducts()
    {
        // var list = shop.ShowAllProducts();

        // foreach (var product in list)
        // {
        //     PrintProduct(product);
        // }
        shop.ShowAllProducts().ForEach(product =>
        {
            PrintProduct(product);
        });
    }
    void PrintProduct(ShowProductDto dto)
    {
        Console.WriteLine($"Id:{dto.Id},Title :{dto.Title} ,Price: {dto.Price} ,Count: {dto.Count}");
    }
    void EditProduct()
    {
        Console.WriteLine("Enter product Id");
        int id = int.Parse(Console.ReadLine());
        if (id == 0)
            return;
        Console.WriteLine("Enter product title");
        string title = Console.ReadLine();
        if (title == "0")
            return;
        Console.WriteLine("Enter product price");
        decimal price = decimal.Parse(Console.ReadLine());
        if (price == 0)
            return;
        Console.WriteLine("Enter product count");
        int count = int.Parse(Console.ReadLine());
        if (count == 0)
            return;

        shop.EditProduct(new EditProductDto
        {
            Id = id,
            Title = title,
            Count = count,
            Price = price
        });
    }
    void DeleteProduct()
    {
        Console.WriteLine("Enter Product Id");
        int id = int.Parse(Console.ReadLine());
        if (id == 0)
            return;
        shop.DeleteProduct(new DeleteProductDto
        {
            Id = id
        });
    }
    public void Start()
    {
        while (true)
        {
            ShowMenu();

            switch (GetUserChoice())
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    ShowAllProducts();
                    break;
                case 3:
                    EditProduct();
                    break;
                case 4:
                    DeleteProduct();
                    break;
                case 0:
                    return;
            }
            Console.WriteLine("press any key to continue ...");
            Console.ReadKey();
        }
    }
}