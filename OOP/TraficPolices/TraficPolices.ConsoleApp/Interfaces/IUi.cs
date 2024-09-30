using Models.Cars;
using Models.Roads;
using Models.SpeedGuards;
using System.Numerics;

namespace TraficPolices.ConsoleApp.Interfaces
{
    public interface IUi
    {
        public int GetIntegerFromUser(string message);
        public BigInteger GetBigIntegerFromUser(string message);
        public string GetStringFromUser(string message);
        public void ShowMessage(string message);
        public Car GetCar();
        public Road GetRoad();
        public SpeedGuard GetSpeedGuard();

    }
}
