using TraficPolices.ConsoleApp.Enums;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class Car(CarType carType, string plaque) : HasIdClass
{
    public override int Id { get; set; }
    public CarType CarType { get; } = carType;
    public string Plaque { get; } = plaque;
}