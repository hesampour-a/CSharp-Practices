using System.Numerics;

namespace Market.Entities.Database;

public class Database
{
    public List<Product> Products { get; set; } = new();
    public List<Sale> Sales { get; set; } = new();
    public void AddNewProduct(Product product)
    {
        int newItemId = Products.Count > 0 ? Products.Last().Id + 1 : 1;
        product.Id = newItemId;
        Products.Add(product);
    }
    public void AddNewSale(Sale sale)
    {
        int newItemId = Sales.Count > 0 ? Sales.Last().Id + 1 : 1;
        sale.Id = newItemId;
        Sales.Add(sale);


    }

    public void PrintProducts()
    {
        foreach (var product in Products)
        {
            Console.WriteLine(product);
        }
    }

    public void PrintSales()
    {
        foreach (var sale in Sales)
        {
            Console.WriteLine(sale);
        }
    }

    public void GetProductFromUser()
    {
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine()!;
        Console.WriteLine("Enter product price:");
        BigInteger price = BigInteger.Parse(Console.ReadLine()!);

        AddNewProduct(new Product
        {
            Name = name,
            Price = price
        });
    }

    public void GetSaleFromUser()
    {
        Console.WriteLine("Enter product id:");
        int productId = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter count:");
        int count = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter date:");
        DateTime date = DateTime.Parse(Console.ReadLine()!);
        AddNewSale(new Sale
        {
            Product = Products.First(x => x.Id == productId),
            Count = count,
            Date = date
        });
    }

    public (Product, int) BestSeller()
    {
        Product bestSeller = new();
        int bestSellerCount = 0;
        int currentCount = 0;
        foreach (var product in Products)
        {
            foreach (var sale in Sales)
            {
                if (product.Id == sale.Product.Id)
                {
                    currentCount++;
                }
            }

            if (currentCount > bestSellerCount)
            {
                bestSellerCount = currentCount;
                bestSeller = product;
            }
        }

        return (bestSeller, bestSellerCount);
    }

    public void PrintReport1()
    {
        (Product bestSeller, int bestSellerCount) = BestSeller();
        Console.WriteLine($"Best Seller: {bestSeller.Name} ({bestSellerCount})");
    }

    public BigInteger CalculateAveragePrice()
    {
        BigInteger priceSum = 0;
        int count = 0;
        foreach (var sale in Sales)
        {
            priceSum += sale.Product.Price * sale.Count;
            count += sale.Count;
        }

        return priceSum / count;
    }

    public void PrintReport2()
    {
        BigInteger averagePrice = CalculateAveragePrice();
        Console.WriteLine($"Average price: {averagePrice}");
    }

    public List<Product> GetProductsWithSaleMoreThanAverage(BigInteger average)
    {
        List<Product> products = new();
        BigInteger productAverage = 0;
        foreach (Product product in Products)
        {
            foreach (var sale in Sales)
            {
                if (product.Id == sale.Product.Id)
                    productAverage += sale.Product.Price * sale.Count;

            }
            product.AverageSale = productAverage;
            if (productAverage >= average)
                products.Add(product);

            productAverage = 0;
        }

        return products;
    }

    public List<Product> SortByAverage(List<Product> products)
    {
        return products.OrderBy(product => product.AverageSale).ToList();
    }

    public void PrintReport3()
    {
        List<Product> sortedProducts = SortByAverage(GetProductsWithSaleMoreThanAverage(CalculateAveragePrice()));

        foreach (var product in sortedProducts)
        {
            Console.WriteLine(product);
        }
    }
}