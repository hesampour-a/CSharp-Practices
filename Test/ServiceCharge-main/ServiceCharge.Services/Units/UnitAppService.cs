using ServiceCharge.Entities;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Exceptions;
using ServiceCharge.Services.UnitOfWorks;
using ServiceCharge.Services.Units.Contracts;
using ServiceCharge.Services.Units.Exceptions;

namespace ServiceCharge.Services.Units;

public class UnitAppService(
    UnitRepository unitRepository,
    UnitOfWork unitOfWork,
    FloorRepository floorRepository) : UnitService
{
    public void Delete(int unitId)
    {
        var unit = unitRepository.Find(unitId)
                   ?? throw new UnitNotFoundException();

        unitRepository.Delete(unit);
        unitOfWork.Save();
    }

    public int Add(int floorId, CreateUnitDto dto)
    {
        var floor = floorRepository.Find(floorId)
                    ?? throw new FloorNotFoundException();

        if (floorRepository.UnitsCount(floorId) >= floor.UnitCount)
            throw new FloorAlredyHasMoreUnitsException();

        var unit = new Unit()
        {
            Name = dto.Name,
            FloorId = floorId,
            IsActive = dto.IsActive,
        };

        unitRepository.Add(unit);
        unitOfWork.Save();
        return unit.Id;
    }

    public void AddRange(List<Unit> units)
    {
        unitRepository.AddRange(units);
        unitOfWork.Save();
    }
}