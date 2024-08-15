using Tickets.Models.Enums;
using Tickets.Models.Models.Trips;
using Tickets.Models.Models.Users;

namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class ShowTicketDto
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public double CancelPrice { get; set; }
}
