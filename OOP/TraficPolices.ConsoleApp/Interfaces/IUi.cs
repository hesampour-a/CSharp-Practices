using System.Numerics;
using TraficPolices.ConsoleApp.Entities;

namespace TraficPolices.ConsoleApp.Interfaces;

public interface IUi
{
    public void ShowMessage(string message);
    public string GetStringFromUser(string message);
    public BigInteger GetBigIntegerFromUser(string message);
    public int GetIntegerFromUser(string message);
    public Car GetCar();
    public Movement GetMovement();
    public Road GetRoad();
    public void Clear();

}