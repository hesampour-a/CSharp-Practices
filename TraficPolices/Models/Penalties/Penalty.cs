using System.Numerics;

namespace Models.Penalties;

public class Penalty(BigInteger amount)
{
    public BigInteger Amount { get; init; } = amount;
}
