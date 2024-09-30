using Models.Interfaces;
using Models.Movements;

namespace Models.SpeedGuards;

public class SpeedGuard(string title) : HasIdClass
{
    public override int Id { get; set; }
    public string Title { get; set; } = title;

    public static Movement RecordMovement(int roadId, string carPlaque, int speed)
    {
        return new Movement(carPlaque, speed, roadId);
    }

}
