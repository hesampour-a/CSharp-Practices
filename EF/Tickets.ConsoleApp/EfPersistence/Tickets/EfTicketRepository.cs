using Microsoft.EntityFrameworkCore;
using Tickets.ConsoleApp.Constants;
using Tickets.ConsoleApp.Dtos.Tickets;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Tickets;

public class EfTicketRepository(EfDataContext dbContext)
{
    public int Create(Ticket newTicket)
    {
        dbContext.Tickets.Add(newTicket);
        return newTicket.Id;
    }

    public List<ShowTicketDto> GetAll()
    {
        return dbContext.Tickets.Include(_ => _.Trip)
            .Select(_ => new ShowTicketDto
            {
                Id = _.Id,
                BuyType = _.BuyType,
                TripId = _.TripId,
                UserId = _.UserId,
                Paid = _.BuyType == BuyType.Buy
                    ? _.Trip.PricePerTicket
                    : _.Trip.PricePerTicket * (decimal)0.30
            }).ToList();
    }

    public Ticket? GetById(int ticketId)
    {
        return dbContext.Tickets
            .Include(_ => _.Trip)
            .FirstOrDefault(_ => _.Id == ticketId);
    }

    public void Delete(Ticket? ticket)
    {
        dbContext.Tickets.Remove(ticket);
    }
}