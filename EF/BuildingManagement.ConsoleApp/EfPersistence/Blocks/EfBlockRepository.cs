using BuildingManagement.ConsoleApp.Dtos.Blocks;
using BuildingManagement.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.ConsoleApp.EfPersistence.Blocks;

public class EfBlockRepository(EfDataContext dbContext)
{
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
                FloorCount = _.Floors.Count
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