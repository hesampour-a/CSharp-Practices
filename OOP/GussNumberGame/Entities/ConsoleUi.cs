namespace GuessNumberGame.Entities;

public class ConsoleUi : IUi
{
    public int GetNumberFromUser()
    {
        Console.WriteLine("Enter a number : ");
        return int.Parse(Console.ReadLine()!);
    }

    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}