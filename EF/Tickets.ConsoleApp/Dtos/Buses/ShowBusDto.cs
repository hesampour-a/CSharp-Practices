using Tickets.ConsoleApp.Constants;

namespace Tickets.ConsoleApp.Dtos.Buses;

public class ShowBusDto
{
    public int Id { get; set; }
    public string Plaque { get; set; }
    public BusType BusType { get; set; }
}