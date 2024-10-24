using ServiceCharge.Entities;

namespace ServiceCharge.Services.Units.Contracts;

public interface UnitRepository
{
    Unit? Find(int unitId);
    void Delete(Unit unit);
    void Add(Unit unit);
    void AddRange(List<Unit> units);
}