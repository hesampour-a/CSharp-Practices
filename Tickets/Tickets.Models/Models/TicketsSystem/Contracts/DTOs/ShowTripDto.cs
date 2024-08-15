namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class ShowTripDto
{
    public int Id { get; set; }
    public string BusType { get; set; } 
    public double TicketPrice { get; set; } 
    public string Date { get; set; } 
    public string OriginCity { get; set; } 
    public string DestinationCity { get; set; } 
    public int RemainingCapacity { get; set; } 
}
