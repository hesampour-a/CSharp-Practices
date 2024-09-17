using Tickets.ConsoleApp.Constants;

namespace Tickets.ConsoleApp.Dtos.Tickets;

public class ShowTicketDto
{
    public int Id { get; set; }
    public BuyType BuyType { get; set; }
    public int TripId { get; set; }
    public int UserId { get; set; }
    public decimal Paid { get; set; }
}