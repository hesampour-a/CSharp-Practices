namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class CreateTicketDto
{
    public int CustomerId { get; set; }
    public int TripId { get; set; }
    public int TicketType { get; set; }
}
