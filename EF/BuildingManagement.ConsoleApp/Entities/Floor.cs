namespace BuildingManagement.ConsoleApp.Entities;

public class Floor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Block Block { get; set; }
    public int BlockId { get; set; }
    public List<Unit> Units { get; set; }
    public int MaxUnitNumber { get; set; }
}