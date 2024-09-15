using BuildingManagement.ConsoleApp.Dtos.Units;
using BuildingManagement.ConsoleApp.Entities;

namespace BuildingManagement.ConsoleApp.EfPersistence.Units;

public class EfUnitRepository(EfDataContext dbContext)
{
    public void Create(Unit newUnit)
    {
        dbContext.Units.Add(newUnit);
    }

    public List<ShowUnitDto> GetAll()
    {
        return dbContext.Units.Select(_ => new ShowUnitDto
        {
            Id = _.Id,
            Name = _.Name,
            FloorId = _.FloorId,
        }).ToList();
    }

    public Unit? GetById(int unitId)
    {
        return dbContext.Units.FirstOrDefault(_ => _.Id == unitId);
    }

    public void Delete(Unit unit)
    {
        dbContext.Units.Remove(unit);
    }
}