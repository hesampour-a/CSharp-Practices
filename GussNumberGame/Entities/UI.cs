namespace GussNumberGame.Entities;

public class UI
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
    public int GetNumberFromUser()
    {
        Console.WriteLine("Enter a number : ");
        return int.Parse(Console.ReadLine()!);
    }
}