using Microsoft.EntityFrameworkCore;
using ZooManagement.ConsoleApp.Dtos.Partitions;
using ZooManagement.ConsoleApp.Dtos.Reports;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Partitions;

public class EfPartitionRepository(EfDataContext dbContext)
{
    public void Create(Partition newPartiton)
    {
        dbContext.Partitions.Add(newPartiton);
    }

    public List<ShowPartitonDto> GetAll()
    {
        return dbContext.Partitions.Select(_ => new ShowPartitonDto
        {
            Id = _.Id,
            AnimalCount = _.AnimalCount,
            Description = _.Description,
            AnimalId = _.AnimalId,
            Area = _.Area,
            ZooId = _.ZooId,
        }).ToList();
    }

    public Partition? GetById(int partitionId)
    {
        return dbContext.Partitions.FirstOrDefault(_ => _.Id == partitionId);
    }

    public void Delete(Partition partition)
    {
        dbContext.Partitions.Remove(partition);
    }

    public List<ShowReport3Dto> GetReport3()
    {
        return dbContext.Partitions.Include(_ => _.Animal).Select(_ =>
            new ShowReport3Dto
            {
                Id = _.Id,
                AnimalCount = _.AnimalCount,
                Description = _.Description,
                AnimalName = _.Animal.Title
            }).ToList();
    }

    public List<ShowReport4Dto> GetReport4()
    {
        return dbContext.Partitions.Include(_ => _.Ticket)
            .ThenInclude(_ => _.SoldTickets).Select(_ => new ShowReport4Dto
            {
                PartitionId = _.Id,
                SoldTicketCount = _.Ticket.SoldTickets.Count
            }).OrderByDescending(_ => _.SoldTicketCount).ToList();
    }

    public List<ShowReport5Dto> GetReport5()
    {
        return dbContext.Partitions.Include(_ => _.Ticket)
            .ThenInclude(_ => _.SoldTickets).Select(_ => new ShowReport5Dto
            {
                PartitionId = _.Id,
                TotalSellCost = _.Ticket.Price * _.Ticket.SoldTickets.Count,
            }).OrderByDescending(_ => _.TotalSellCost).ToList();
    }
}