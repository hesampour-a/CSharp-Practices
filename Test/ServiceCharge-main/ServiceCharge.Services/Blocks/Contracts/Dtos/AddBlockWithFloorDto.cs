using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Services.Blocks.Contracts.Dtos;

public class AddBlockWithFloorDto
{
    public List<FloorAddDto> Floors { get; set; } = [];
    public required string Name { get; set; }
}