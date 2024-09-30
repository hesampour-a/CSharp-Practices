using OnlineShopManagements.ConsoleApp.Interfaces;
using static System.Console;
namespace OnlineShopManagements.ConsoleApp.UIs;

internal class ConsoleUi : IUi
{
    public double GetDouble(string message)
    {
        bool isInputValid = false;
        double input = 0;
        while (!isInputValid)
        {
            WriteLine(message);
            isInputValid = double.TryParse(ReadLine(), out double value);
            if (!isInputValid)
            {
                WriteLine($"Enter a valid number is not valid.");
            }
            if(isInputValid)
                input = value;
        }
        return input;

    }

    public int GetInt(string message)
    {
        bool isInputValid = false;
        int input = 0;
        while (!isInputValid)
        {
            WriteLine(message);
            isInputValid = int.TryParse(ReadLine(), out int value);
            if (!isInputValid)
            {
                WriteLine($"Enter a valid number is not valid.");
            }
            if(isInputValid)
                input = value;
        }
        return input;
    }
    public string GetString(string message)
    {
        WriteLine(message);
        return ReadLine()!;
    }

    public void ShowMessage(string message)
    {
        WriteLine($"{message}");
    }
}
