using System.Numerics;

namespace RentServiceOOP.Entities;

public class Income
{
    public BigInteger Amount { get; set; }
    public int ContractId { get; set; }
    public int MyProperty { get; set; }

    void Test()
    {
        MyProperty = 1;
    }
}