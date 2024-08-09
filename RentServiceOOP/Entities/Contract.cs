using System.Numerics;
using RentServiceOOP.Interfaces;

namespace RentServiceOOP.Entities;

public class Contract : HasIdClass
{
    public override int Id { get; set; }
    public int HouseId { get; set; }
    public int TenantId { get; set; }
    public int OwnerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
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

}