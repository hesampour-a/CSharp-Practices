using ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts;
using ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts.Dtos;
using ServiceCharge.Entities;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Contracts.Dtos;
using ServiceCharge.Services.UnitOfWorks;
using ServiceCharge.Services.Units.Contracts;

namespace ServiceCharge.Application.Floors.AddFloorAndUnits;

public class AddFloorAndUnitsCommandHandler(
    UnitOfWork unitOfWork,
    FloorService floorService,
    UnitService unitService) : AddFloorAndUnitsHandler
{
    public int AddSingleFloorWithUnits(int blockId, AddFloorAndUnitsDto dto)
    {
        unitOfWork.Begin();
        try
        {
            var floorId = floorService.Add(blockId, new FloorAddDto()
            {
                Name = dto.Name,
                UnitCount = dto.Units.Count
            });

            var units = new List<Unit>();

            dto.Units.ForEach(_ =>
            {
                units.Add(new Unit()
                {
                    Name = _.Name,
                    FloorId = floorId,
                    IsActive = _.IsActive,
                });
            });
            
            unitService.AddRange(units);

            unitOfWork.Commit();
            return floorId;
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
            throw;
        }
    }
}