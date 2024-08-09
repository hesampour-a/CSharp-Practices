using System.Numerics;
using RentServiceOOP.Interfaces;

namespace RentServiceOOP.Entities;

public class House : HasIdClass
{
    public override int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    private BigInteger _rentRate;
    public BigInteger RentRate
    {
        get { return _rentRate; }
        set { if (value <= 2000000) _rentRate = value; }
    }
    private BigInteger _mortgageRate;
    public BigInteger MortgageRate
    {
        get { return _mortgageRate; }
        set { if (value <= 30000000) _mortgageRate = value; }
    }
    public int OwnerId { get; set; }


}