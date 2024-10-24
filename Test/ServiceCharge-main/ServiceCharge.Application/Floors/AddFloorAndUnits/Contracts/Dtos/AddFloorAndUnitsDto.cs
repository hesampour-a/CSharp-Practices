namespace ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts.Dtos;

public class AddFloorAndUnitsDto
{
    public string Name { get; set; }
    public List<AddUnitDto> Units { get; set; }
}

public class AddUnitDto
{
    public required string Name { get; set; }
    public bool IsActive { get; set; }
}