using BuildingManagement.ConsoleApp.Dtos.Costs;
using BuildingManagement.ConsoleApp.Entities;

namespace BuildingManagement.ConsoleApp.EfPersistence.Costs;

public class EfCostRepository(EfDataContext dbContext)
{
    public int Create(Cost newCost)
    {
        dbContext.Costs.Add(newCost);
        return newCost.Id;
    }

    public List<ShowCostDto> GetAll()
    {
        return dbContext.Costs.Select(_ => new ShowCostDto
        {
            Id = _.Id,
            TotalCost = _.TotalCost,
            Description = _.Description,
            BlockId = _.BlockId,
        }).ToList();
    }

    public Cost? GetById(int costId)
    {
        return dbContext.Costs.FirstOrDefault(_ => _.Id == costId);
    }

    public void Delete(Cost cost)
    {
        dbContext.Costs.Remove(cost);
    }
}