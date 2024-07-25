using System.Numerics;

namespace Mountaineering.Entities;

public class Mountain
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public BigInteger Height { get; set; }

    public void PrintMountain()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Height: {Height}");
    }
}