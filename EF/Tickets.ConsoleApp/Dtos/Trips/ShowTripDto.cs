namespace Tickets.ConsoleApp.Dtos.Trips;

public class ShowTripDto
{
    public int Id { get; set; }
    public string OriginCity { get; set; } = String.Empty;
    public string DestinationCity { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public int? BusId { get; set; }
    public decimal PricePerTicket { get; set; }
}