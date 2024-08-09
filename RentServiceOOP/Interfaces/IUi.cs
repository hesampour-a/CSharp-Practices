using System.Numerics;
using RentServiceOOP.Entities;

namespace RentServiceOOP.Interfaces;

public interface IUi
{
    public string GetStringFromUser(string message);
    public BigInteger GetBigIntegerFromUser(string message);
    public int GetIntegerFromUser(string message);
    public User GetUser();
    public Contract GetContract();
    public House GetHouse();
    public DateTime GetDateTimeFromUser(string message);

}