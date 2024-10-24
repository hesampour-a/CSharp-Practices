using ServiceCharge.Entities;
using ServiceCharge.Services.Units.Contracts;

namespace ServiceCharge.Persistence.Ef.Units;

public class EFUnitRepository(EfDataContext context) : UnitRepository
{
    public Unit? Find(int unitId)
    {
        return context.Set<Unit>().FirstOrDefault(x => x.Id == unitId);
    }

    public void Delete(Unit unit)
    {
        context.Set<Unit>().Remove(unit);
    }

    public void Add(Unit unit)
    {
        context.Set<Unit>().Add(unit);
    }

    public void AddRange(List<Unit> units)
    {
        context.Set<Unit>().AddRange(units);
    }
}