using TraficPolices.ConsoleApp.Enums;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class SpeedLimit
{
    public CarType CarType { get; set; }
    public int ValidSpeed { get; set; }
}