using Models.Interfaces;
using Models.SpeedLimits;

namespace Models.Roads;

public class Road(string startPoint,string endPoint,List<SpeedLimit> speedLimits) : HasIdClass
{
    public override int Id { get; set; }
    public string StratPoint { get; init; } = startPoint;
    public string EndPoint { get; init; } = endPoint;
    public List<SpeedLimit> SpeedLimits { get; init; } = speedLimits;
}
