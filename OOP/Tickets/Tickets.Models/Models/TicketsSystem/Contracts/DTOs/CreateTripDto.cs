using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using Tickets.Models.Models.Buses;

namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class CreateTripDto
{
    public int BusId { get; set; } 
    public double TicketPrice { get; set; } 
    public DateTime Date { get; set; } 
    public int OriginCityId { get; set; } 
    public int DestinationCityId { get; set; } 
}
