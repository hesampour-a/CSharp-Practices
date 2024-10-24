using ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts;
using ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts.Dtos;
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
        try
        {
            unitOfWork.Begin();

            var floorId = floorService.Add(blockId, new FloorAddDto()
            {
                Name = dto.Name,
                UnitCount = dto.Units.Count
            });
            
            dto.Units.ForEach(_ =>
            {
                unitService.Add(floorId, new CreateUnitDto()
                {
                    Name = _.Name,
                    IsActive = _.IsActive,
                });
            });


            unitOfWork.Commit();
            return floorId;
        }
        catch (Exception e)
        {
            unitOfWork.Rollback();
        }

        return 0;
    }
}