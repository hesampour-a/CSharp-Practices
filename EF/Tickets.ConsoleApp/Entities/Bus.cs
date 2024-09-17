using Tickets.ConsoleApp.Constants;

namespace Tickets.ConsoleApp.Entities;

public class Bus
{
    public int Id { get; set; }
    public BusType BusType { get; set; }
    public string Plaque { get; set; } = String.Empty;
    public List<Trip> Trips { get; set; } = [];
}