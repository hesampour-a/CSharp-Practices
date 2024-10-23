namespace ServiceCharge.Services.Units.Contracts;

public interface UnitQuery
{
    List<GetAllWithBlockNameAndFloorNameDto> GetAllWithBlockNameAndFloorName();
}

public class GetAllWithBlockNameAndFloorNameDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int FloorId { get; set; }
    public bool IsActive { get; set; }
    public required string BlockName { get; set; }
    public required string? FloorName { get; set; }
}