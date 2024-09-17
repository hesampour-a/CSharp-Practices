using Microsoft.EntityFrameworkCore;
using ZooManagement.ConsoleApp.Dtos.Animals;
using ZooManagement.ConsoleApp.Dtos.Partitions;
using ZooManagement.ConsoleApp.Dtos.Reports;
using ZooManagement.ConsoleApp.Dtos.Tickets;
using ZooManagement.ConsoleApp.Dtos.Zooes;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Zooes;

public class EfZooRepository(EfDataContext dbContext)
{
    public void Create(Zoo newZoo)
    {
        dbContext.Zooes.Add(newZoo);
    }

    public List<ShowZooDto> GetAll()
    {
        return dbContext.Zooes.Select(_ => new ShowZooDto
        {
            Id = _.Id,
            Name = _.Name,
            Address = _.Address,
        }).ToList();
    }

    public Zoo? GetById(int zooId)
    {
        return dbContext.Zooes.FirstOrDefault(_ => _.Id == zooId);
    }

    public void Delete(Zoo zoo)
    {
        dbContext.Zooes.Remove(zoo);
    }

    public List<ShowReport1Dto> GetReport1()
    {
        return dbContext.Zooes.Include(_ => _.Partitions)
            .ThenInclude(_ => _.Animal)
            .Select(_ => new ShowReport1Dto
            {
                Name = _.Name,
                Address = _.Address,
                Animals = _.Partitions.Select(a => new ShowAnimalDto
                {
                    Id = a.Animal.Id,
                    Title = a.Animal.Title,
                }).ToList(),
            }).ToList();
    }

    public List<ShowReport2Dto> GetReport2()
    {
        return dbContext.Zooes.Include(_ => _.Partitions)
            .ThenInclude(_ => _.Ticket).Select(_ => new ShowReport2Dto
            {
                Name = _.Name,
                PartitionsCount = _.Partitions.Count(),
                Partitons = _.Partitions.Select(p=>new ShowPartitionForReport2Dto()
                {
                   TicketPrice = p.Ticket.Price,
                    Area = p.Area,
                    
                }).ToList(),
            }).ToList();
    }
}