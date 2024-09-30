using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class Road : HasIdClass
{
    public override int Id { get; set; }
    public List<SpeedLimit> SpeedLimits { get; set; } = [];
}