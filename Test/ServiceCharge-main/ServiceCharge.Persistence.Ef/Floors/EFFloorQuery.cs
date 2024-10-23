using ServiceCharge.Entities;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Persistence.Ef.Floors;

public class EFFloorQuery(EfDataContext context) : FloorQuery
{
    public List<GetAllFloorsDto> GetAll()
    {
        return context.Set<Floor>().Select(_ => new GetAllFloorsDto
        {
            Id = _.Id,
            Name = _.Name,
            UnitCount = _.UnitCount,
            BlockId = _.BlockId,
        }).ToList();
    }

    public List<GetAllFloorsWithUnitsDto> GetAllWithUnits()
    {
        return context.Set<Floor>()
            .Select(_ => new GetAllFloorsWithUnitsDto
            {
                Id = _.Id,
                Name = _.Name,
                UnitCount = _.UnitCount,
                BlockId = _.BlockId,
                Units = context.Set<Unit>()
                    .Where(u => u.FloorId == _.Id)
                    .Select(
                        _ => new GetAllUnitsDto()
                        {
                            Id = _.Id,
                            Name = _.Name,
                            IsActive = _.IsActive,
                            FloorId = _.FloorId,
                        }).ToList()
            }).ToList();
    }
}