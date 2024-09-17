using Tickets.ConsoleApp.Constants;

namespace Tickets.ConsoleApp.Entities;

public class Ticket
{
    public int Id { get; set; }
    public BuyType BuyType { get; set; }
    public Trip Trip { get; set; }
    public int TripId { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
}