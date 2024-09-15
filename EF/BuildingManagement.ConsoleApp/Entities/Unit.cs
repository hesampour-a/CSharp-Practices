namespace BuildingManagement.ConsoleApp.Entities;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Floor Floor { get; set; }
    public int FloorId { get; set; }
}