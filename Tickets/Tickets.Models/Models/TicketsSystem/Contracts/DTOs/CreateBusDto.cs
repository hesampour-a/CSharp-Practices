using Tickets.Models.Enums;

namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class CreateBusDto
{
    public string LicensePlate { get; set; }
    public int Type { get; set; }
    public int Capacity { get; set; } 
}
