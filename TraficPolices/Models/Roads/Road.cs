using Models.Interfaces;
using Models.SpeedLimits;

namespace Models.Roads;

public class Road(string title,List<SpeedLimit> speedLimits) : HasIdClass
{
    public override int Id { get; set; }
    public string Title { get; set; } = title;
    public List<SpeedLimit> SpeedLimits { get; init; } = speedLimits;
}
