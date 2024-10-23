namespace ServiceCharge.Services.Blocks.Contracts.Dtos;

public class GetAllBlocksDto
{
    public int Id { get; set; }
    public int FloorCount { get; set; }
    public required string Name { get; set; }
    public DateTime CreationDate { get; set; }
}