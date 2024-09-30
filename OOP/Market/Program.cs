using Market.Entities.Database;

var database = new Database();

Run();

void Run()
{
    while (true)
    {
        Console.WriteLine("1. Add new product");
        Console.WriteLine("2. Add new sale");
        Console.WriteLine("3. Report #1");
        Console.WriteLine("4. Report #2");
        Console.WriteLine("5. Report #3");
        Console.WriteLine("6. Exit");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                database.GetProductFromUser();
                break;
            case "2":
                Console.WriteLine("Enter Valid sale Count:");
                int validSaleCount = int.Parse(Console.ReadLine()!);
                for (int i = 0; i < validSaleCount; i++)
                {
                    database.GetSaleFromUser();
                }
                break;
            case "3":
                database.PrintReport1();
                break;
            case "4":
                database.PrintReport2();
                break;
            case "5":
                database.PrintReport3();
                break;
            case "6":
                return;
            default:
                break;
        }
    }
}

