namespace ServiceCharge.Services.Floors.Contracts.Dtos;

public class GetAllFloorsDto
{
    public int Id { get; set; }
    public int UnitCount { get; set; }
    public required string Name { get; set; }
    public int BlockId { get; set; }
}