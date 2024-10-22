using ServiceCharge.Entities;

namespace ServiceCharge.Services.Blocks;

public class BlockAppService(
    BlockRepository blockRepository,
    DateTimeService dateTimeService) : BlockService
{
    public void Add(AddBlockDto dto)
    {
        var block = new Block()
        {
            Name = dto.Name,
            FloorCount = dto.FloorCount,
            CreationDate = dateTimeService.NowUtc
        };

        blockRepository.Add(block);
    }
}