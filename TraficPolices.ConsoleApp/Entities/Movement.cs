namespace TraficPolices.ConsoleApp.Entities;

public class Movement
{
    public int RoadId { get; set; }
    public string CarPlaque { get; set; } = String.Empty;
    public int Speed { get; set; }
}