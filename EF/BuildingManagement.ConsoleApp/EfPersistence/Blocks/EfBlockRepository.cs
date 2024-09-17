using BuildingManagement.ConsoleApp.Dtos.Blocks;
using BuildingManagement.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.ConsoleApp.EfPersistence.Blocks;

public class EfBlockRepository(EfDataContext dbContext)
{
    public List<ShowBlockReportDto> GetBlockReport()
    {
        // return dbContext.Blocks
        //     .Include(_ => _.Floors)
        //     .ThenInclude(_ => _.Units)
        //     .Include(_ => _.Costs)
        //     .Select(_ => new ShowBlockReportDto
        //     {
        //         Name = _.Name,
        //         MaxFloorNumber = _.MaxFloorNumber,
        //         Costs = _.Costs,
        //         FloorsCount = _.Floors.Count,
        //         //UnitsCount = _.Floors.Sum(_ => _.Units.Count),
        //     }).ToList();

        var dtos = 
            (from block in dbContext.Blocks
            join floor in dbContext.Floors
                on block.Id equals floor.BlockId
            select new ShowBlockReportDto
            {
                Name = block.Name,
                MaxFloorNumber = block.MaxFloorNumber,
                Costs = (from b in dbContext.Blocks
                    where b.Id == block.Id
                    join cost in dbContext.Costs
                        on b.Id equals cost.BlockId
                    select new Cost
                    {
                        Id = cost.Id,
                        BlockId = cost.BlockId,
                        TotalCost = cost.TotalCost,
                        Description = cost.Description,
                    }).ToList(),
                FloorsCount = block.Floors.Count,
                //UnitsCount = block.Floors.Sum(_ => _.Units.Count),
                UnitsCount = (from b in dbContext.Blocks
                    where b.Id == block.Id
                    join f in dbContext.Floors
                        on b.Id equals f.BlockId
                    join u in dbContext.Units
                        on f.Id equals u.FloorId
                    select new
                    {
                        Id = u.Id,
                    }).Count(),
            }).GroupBy(_ => _.Name).Select(_ => new ShowBlockReportDto
        {
            Name = _.Key,
            FloorsCount = _.Count(),
            Costs = _.First().Costs,
            MaxFloorNumber = _.First().MaxFloorNumber,
            UnitsCount = _.First().UnitsCount
        }).ToList();


        return dtos;
    }

    public int Create(Block newBlock)
    {
        dbContext.Blocks.Add(newBlock);
        return newBlock.Id;
    }

    public void Save()
    {
        dbContext.SaveChanges();
    }

    public List<ShowBlockDto> GetAll()
    {
        return (dbContext.Blocks.Include(_ => _.Floors).Select(_ =>
            new ShowBlockDto
            {
                Id = _.Id,
                Name = _.Name,
                FloorCount = _.Floors.Count,
                MaxFloorNumber = _.MaxFloorNumber,
            })).ToList();
    }

    public Block? GetById(int blockId)
    {
        return dbContext.Blocks.Include(_ => _.Floors)
            .FirstOrDefault(_ => _.Id == blockId);
    }

    public void Delete(Block block)
    {
        dbContext.Blocks.Remove(block);
    }
}