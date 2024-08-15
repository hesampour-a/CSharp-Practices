using System.Xml.Linq;

namespace Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

public class CreateCustomerDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty ;
    public string NationalCode { get; set; } = string.Empty;
}
