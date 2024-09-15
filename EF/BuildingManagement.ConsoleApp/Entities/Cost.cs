namespace BuildingManagement.ConsoleApp.Entities;

public class Cost
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public decimal TotalCost { get; set; }
    public Block Block { get; set; }
    public int BlockId { get; set; }
}