using BuildingManagement.ConsoleApp.Dtos.Costs;
using BuildingManagement.ConsoleApp.Entities;

namespace BuildingManagement.ConsoleApp.Dtos.Blocks;

public class ShowBlockReportDto
{
    public string Name { get; set; }
    public int MaxFloorNumber { get; set; }
    public int FloorsCount { get; set; }
    public List<Cost> Costs { get; set; }
    public int UnitsCount { get; set; }
}