using Models.Enums;
using Models.Interfaces;
using Models.Penalties;

namespace Models.Cars;

public class Car(CarType type, string plaque) : HasIdClass
{
    public override int Id { get; set; }
    public string Plaque { get; init; } = plaque;
    public CarType Type { get; init; } = type;
    public List<Penalty> Penalties { get; } = [];
}
