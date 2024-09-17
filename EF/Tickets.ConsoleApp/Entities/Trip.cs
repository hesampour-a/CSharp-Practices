namespace Tickets.ConsoleApp.Entities;

public class Trip
{
    public int Id { get; set; }
    public string OriginCity { get; set; } = String.Empty;
    public string DestinationCity { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public decimal PricePerTicket { get; set; }
    public Bus? Bus { get; set; }
    public int? BusId { get; set; }
    public List<Ticket> Tickets { get; set; } = [];
}