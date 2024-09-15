namespace BuildingManagement.ConsoleApp.Entities;

public class Block
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Floor> Floors { get; set; }
    public int MaxFloorNumber { get; set; }
    public List<Cost> Costs { get; set; }

}