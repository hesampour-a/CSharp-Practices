using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Services.Blocks.Contracts.Dtos;

public class GetSingleBlockWithFloorsDto
{
    public int FloorCount { get; set; }
    public required string Name { get; set; }
    public DateTime CreationDate { get; set; }

    public List<GetAllFloorsDto> Floors { get; set; } = [];
}