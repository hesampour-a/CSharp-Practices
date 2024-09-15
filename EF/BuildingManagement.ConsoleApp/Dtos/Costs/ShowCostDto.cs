namespace BuildingManagement.ConsoleApp.Dtos.Costs;

public class ShowCostDto
{
    public int Id { get; set; }
    public int BlockId { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}