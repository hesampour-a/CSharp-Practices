using Tickets.ConsoleApp.Interfaces;

namespace Tickets.ConsoleApp.IOs;

public class ConsoleUi : IConsoleUi
{
    public string GetString(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public int GetInt(string message)
    {
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }

    public double GetDouble(string message)
    {
        Console.WriteLine(message);
        return double.Parse(Console.ReadLine());
    }
    public DateTime GetDate(string message)
    {
        Console.WriteLine(message);
        return DateTime.Parse(Console.ReadLine());
    }
    public void Clear()
    {
        Console.Clear();
    }
    public void Show(string message)
    {
        Console.WriteLine(message);
    }
}
