using ServiceCharge.Entities;
using ServiceCharge.Service.Unit.Tests.Floors;
using ServiceCharge.Services.Blocks.Exceptions;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Contracts.Dtos;
using ServiceCharge.Services.Floors.Exceptions;
using ServiceCharge.Services.UnitOfWorks;

namespace ServiceCharge.Services.Floors;

public class FloorAppService(
    FloorRepository floorRepository,
    BlockRepository blockRepository,
    UnitOfWork unitOfWork) : FloorService
{
    public int Add(int blockId, FloorAddDto dto)
    {
        var block = blockRepository.Find(blockId)
                    ?? throw new BlockNotFoundException();

        if (block.FloorCount <= block.Floors.Count)
            throw new BlockIsInMaxFloorsCountNumberException();

        var floor = new Floor()
        {
            Name = dto.Name,
            UnitCount = dto.UnitCount,
            BlockId = blockId,
        };
        floorRepository.Add(floor);
        unitOfWork.Save();
        return floor.Id;
    }

    public void Update(int floorId, FloorUpdateDto dto)
    {
        var floor = floorRepository.Find(floorId)
                    ?? throw new FloorNotFoundException();

        if (dto.UnitCount < floorRepository.UnitsCount(floorId))
            throw new FloorAlredyHasMoreUnitsException();

        floor.Name = dto.Name;
        floor.UnitCount = dto.UnitCount;
        floorRepository.Update(floor);
        unitOfWork.Save();
    }

    public void Delete(int floorId)
    {
        var floor = floorRepository.Find(floorId)
                    ?? throw new FloorNotFoundException();
        
        var block = blockRepository.Find(floor.BlockId);
        
        if (floorRepository.UnitsCount(floorId) > 0)
            throw new FloorHasUnitsException();
        
        floorRepository.Delete(floor);
        unitOfWork.Save();

        if (block.Floors.Count == 0)
        {
            //blockService.Delete() //Handler???
        }
        
    }
}