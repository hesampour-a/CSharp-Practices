using Tickets.Models.Enums;

namespace Tickets.Models.Models.Buses;

internal class Bus(string licensePlate, BusType type,int capacity)
{
    public string LicensePlate { get; init; } = licensePlate;
    public BusType Type { get; init; } = type;
    public int Capacity { get; init; } = capacity;

}
