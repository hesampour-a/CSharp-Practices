using S4.IOs.Interfaces;

namespace S4.IOs;

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

    public string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }
}