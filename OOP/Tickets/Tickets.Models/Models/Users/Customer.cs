namespace Tickets.Models.Models.Users;

internal class Customer(string phoneNumber,string name,string nationalCode)
{
    public string PhoneNumber { get; init; } = phoneNumber;
    public string Name { get; init; } = name;
    public string NationalCode { get; init; } = nationalCode;
}
