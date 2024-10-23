using ServiceCharge.Services.Blocks.Contracts.Dtos;

namespace ServiceCharge.Services.Blocks.Contracts;

public interface BlockQuery
{
    GetSingleBlockWithFloorsDto Get(int block1Id);
    List<GetAllBlocksDto> GetAll();
    List<GetAllBlocksWithFloorsDto> GetAllWithFloors();
}