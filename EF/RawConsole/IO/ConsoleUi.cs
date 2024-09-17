using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO;

public class ConsoleUi : IUi
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public int GetIntegerFromUser(string message)
    {
        Console.WriteLine(message);
        var isNumberValid = false;
        var number = 0;
        while (!isNumberValid)
        {
            isNumberValid = int.TryParse(Console.ReadLine(), out var result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }

        return number;
    }

    public decimal GetDecimalFromUser(string message)
    {
        Console.WriteLine(message);
        var isNumberValid = false;
        decimal number = 0;
        while (!isNumberValid)
        {
            isNumberValid =
                decimal.TryParse(Console.ReadLine(), out var result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }

        return number;
    }

    public string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }
}