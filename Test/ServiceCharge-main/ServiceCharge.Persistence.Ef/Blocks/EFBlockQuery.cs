using Microsoft.EntityFrameworkCore;
using ServiceCharge.Entities;
using ServiceCharge.Services.Blocks.Contracts;
using ServiceCharge.Services.Blocks.Contracts.Dtos;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Persistence.Ef.Blocks;

public class EFBlockQuery(EfDataContext context) : BlockQuery
{
    public GetSingleBlockWithFloorsDto Get(int block1Id)
    {
        return context.Set<Block>()
            .Where(_ => _.Id == block1Id)
            .Select(_ =>
                new GetSingleBlockWithFloorsDto()
                {
                    Name = _.Name,
                    FloorCount = _.FloorCount,
                    CreationDate = _.CreationDate,
                    Floors = _.Floors
                        .Select(f => new GetAllFloorsDto()
                        {
                            Id = f.Id,
                            Name = f.Name,
                            UnitCount = f.UnitCount,
                            BlockId = f.BlockId,
                        }).ToList()
                        
                }).SingleOrDefault();
    }

    public List<GetAllBlocksDto> GetAll()
    {
        return context.Set<Block>().Select(_ => new GetAllBlocksDto()
        {
            Name = _.Name,
            CreationDate = _.CreationDate,
            FloorCount = _.FloorCount,
            Id = _.Id,
        }).ToList();
    }

    public List<GetAllBlocksWithFloorsDto> GetAllWithFloors()
    {
        return context.Set<Block>()
            .Select(_ => new GetAllBlocksWithFloorsDto()
        {
            Name = _.Name,
            FloorCount = _.FloorCount,
            CreationDate = _.CreationDate,
            Id = _.Id,
            Floors = _.Floors.Select(f => new GetAllFloorsDto()
                {
                    Id = f.Id,
                    Name = f.Name,
                    UnitCount = f.UnitCount,
                    BlockId = f.BlockId,
                }).ToList()
        }).ToList();
    }
}