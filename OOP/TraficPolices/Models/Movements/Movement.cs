using Models.Roads;

namespace Models.Movements;

public class Movement(string carPlaque,int speed,int roadId)
{
    public string CarPlaque { get; init; } = carPlaque;
    public int Speed { get; init; } = speed;
    public int RoadId { get; init; } = roadId;
}
