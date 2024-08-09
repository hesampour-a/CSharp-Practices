using TraficPolices.ConsoleApp.Enums;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class Car : HasIdClass
{
    public override int Id { get; set; }
    public CarType CarType { get; set; }
    public string Plaque { get; set; } = string.Empty;
}