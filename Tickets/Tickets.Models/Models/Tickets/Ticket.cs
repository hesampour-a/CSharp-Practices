using Tickets.Models.Enums;
using Tickets.Models.Models.Trips;
using Tickets.Models.Models.Users;

namespace Tickets.Models.Models.Tickets;

internal class Ticket(Customer customer,Trip trip,TicketType type)
{
    public Customer Customer { get; init; } = customer;
    public Trip Trip { get; init; } = trip;
    public TicketType Type { get; init; } = type;
}
