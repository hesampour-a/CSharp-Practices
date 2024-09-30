using Tickets.Models.Models.Buses;
using Tickets.Models.Models.Tickets;

namespace Tickets.Models.Models.Trips;

internal class Trip(Bus bus,double 
    ticketPrice,City originCity,City destinationCity,DateTime date)
{
    public Bus Bus { get; init; } = bus;
    public double TicketPrice { get; init; } = ticketPrice;
    public DateTime Date { get; init; } = date;
    public City OriginCity { get; init; } = originCity;
    public City DestinationCity { get; init; } = destinationCity;
    public List<Ticket> SoldTickets { get; set; } = [];
}
