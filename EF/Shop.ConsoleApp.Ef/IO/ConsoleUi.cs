using Shop.ConsoleApp.Ef.IO.Interfaces;

namespace Shop.ConsoleApp.Ef.IO;

public class ConsoleUi : IUi
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public int GetIntegerFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        int number = 0;
        while (!isNumberValid)
        {
            isNumberValid = int.TryParse(Console.ReadLine(), out int result);
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
        bool isNumberValid = false;
        decimal number = 0;
        while (!isNumberValid)
        {
            isNumberValid = decimal.TryParse(Console.ReadLine(), out decimal result);
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