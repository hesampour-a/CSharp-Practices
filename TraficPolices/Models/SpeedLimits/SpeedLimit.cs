using Models.Enums;

namespace Models.SpeedLimits;

public class SpeedLimit(CarType carType, int validSpeed)
{
    public CarType CarType { get; init; } = carType;
    public int ValidSpeed { get; init; } = validSpeed;
}
