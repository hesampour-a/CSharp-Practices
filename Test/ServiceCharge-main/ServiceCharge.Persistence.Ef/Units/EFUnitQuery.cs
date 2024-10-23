using ServiceCharge.Entities;
using ServiceCharge.Services.Units.Contracts;

namespace ServiceCharge.Persistence.Ef.Units;

public class EFUnitQuery(EfDataContext context) : UnitQuery
{
    public List<GetAllWithBlockNameAndFloorNameDto>
        GetAllWithBlockNameAndFloorName()
    {
        return context.Set<Unit>()
            .Select(_ =>
                new GetAllWithBlockNameAndFloorNameDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    FloorId = _.FloorId,
                    IsActive = _.IsActive,
                    FloorName = context.Set<Floor>()
                        .Where(f => f.Id == _.FloorId)
                        .Select(f => f.Name)
                        .FirstOrDefault(),
                    BlockName = context.Set<Block>()
                        .Where(b =>
                            b.Id == (context.Set<Floor>()
                                .Where(f => f.Id == _.FloorId)
                                .Select(f => f.BlockId)
                                .First()))
                        .Select(b => b.Name)
                        .First()
                }).ToList();
    }
}