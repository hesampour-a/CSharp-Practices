using ServiceCharge.Entities;

namespace ServiceCharge.Services.Units.Contracts;

public interface UnitService
{
    void Delete(int unitId);
    int Add(int floorId, CreateUnitDto dto);
    void AddRange(List<Unit> units);
}

public class CreateUnitDto
{
    public required string Name { get; set; }
    public bool IsActive { get; set; }
}