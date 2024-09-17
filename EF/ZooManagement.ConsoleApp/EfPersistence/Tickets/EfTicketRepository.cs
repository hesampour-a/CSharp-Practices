using ZooManagement.ConsoleApp.Dtos.Tickets;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Tickets;

public class EfTicketRepository(EfDataContext dbContext)
{
    public bool ExistsForPartition(int partitionId)
    {
        return dbContext.Tickets.Any(
            ticket => ticket.PartitionId == partitionId);
    }

    public void Create(Ticket newTicket)
    {
        dbContext.Tickets.Add(newTicket);
    }

    public List<ShowTicketDto> GetAll()
    {
        return dbContext.Tickets.Select(_ => new ShowTicketDto
        {
            Id = _.Id,
            PartitionId = _.PartitionId,
            Price = _.Price,
        }).ToList();
    }

    public Ticket? GetById(int ticketId)
    {
        return dbContext.Tickets.FirstOrDefault(ticket =>
            ticket.Id == ticketId);
    }

    public void Delete(Ticket ticket)
    {
        dbContext.Tickets.Remove(ticket);
    }
}