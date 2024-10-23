using ServiceCharge.Services.Blocks.Contracts.Dtos;

namespace ServiceCharge.Services.Blocks.Contracts;

public interface BlockService
{
    int Add(AddBlockDto dto);
    void AddWithFloor(AddBlockWithFloorDto dto);
    void Update(int blockId, UpdateBlockDto dto);
}