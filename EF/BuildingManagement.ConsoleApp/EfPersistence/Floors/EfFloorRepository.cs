using BuildingManagement.ConsoleApp.Dtos.Floors;
using BuildingManagement.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.ConsoleApp.EfPersistence.Floors;

public class EfFloorRepository(EfDataContext dbContext)
{
    public int Create(Floor newFloor)
    {
        dbContext.Floors.Add(newFloor);
        return newFloor.Id;
    }

    public List<ShowFloorDto> GetAll()
    {
        return dbContext.Floors.Select(_ => new ShowFloorDto
        {
            Id = _.Id,
            Name = _.Name,
            BlockId = _.BlockId,
            UnitsMaxNumber = _.MaxUnitNumber
        }).ToList();
    }

    public Floor? GetById(int floorId)
    {
        return dbContext.Floors.Include(_ => _.Units)
            .FirstOrDefault(_ => _.Id == floorId);
    }

    public void Delete(Floor floor)
    {
        dbContext.Floors.Remove(floor);
    }
}