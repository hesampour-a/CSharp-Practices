using RentServiceOOP.Interfaces;

namespace RentServiceOOP.Entities;

public class User : HasIdClass
{
    public override int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

}