using System.Numerics;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class Penalty
{
    public int CarId { get; set; }
    public BigInteger Amount { get; set; }
}