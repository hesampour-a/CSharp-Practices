using Tickets.ConsoleApp.Dtos.Buses;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Buses;

public class EfBusRepository(EfDataContext dbContext)
{
    public int Create(Bus newBus)
    {
        dbContext.Buses.Add(newBus);
        return newBus.Id;
    }

    public List<ShowBusDto> GetAll()
    {
        return dbContext.Buses.Select(_ => new ShowBusDto
        {
            Id = _.Id,
            Plaque = _.Plaque,
            BusType = _.BusType,
        }).ToList();
    }

    public Bus? GetById(int busId)
    {
        return dbContext.Buses.FirstOrDefault(_ => _.Id == busId);
    }

    public void Delete(Bus bus)
    {
        dbContext.Remove(bus);
    }
}