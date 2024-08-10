using Models.Cars;
using Models.Interfaces;
using Models.Roads;
using Models.SpeedGuards;

namespace Models.Databases;

public class Database
{
    public List<Road> Roads { get; } = [];
    public List<Car> Cars { get; } = [];
    public List<SpeedGuard> SpeedGuards { get; } = [];

   static int CalculateNewItemId<T>(List<T> list) where T : HasIdClass
    {
        return list.Count > 0 ? list.Last().Id + 1 : 1;
    }

    public void RegisterRoad(Road road)
    {
        road.Id = CalculateNewItemId(Roads);
        Roads.Add(road);
    }
    public void RegisterCar(Car car)
    {
        car.Id = CalculateNewItemId(Cars);
        Cars.Add(car);
    }
    public void RegisterSpeedGuard(SpeedGuard speedguard)
    {
        speedguard.Id = CalculateNewItemId(SpeedGuards);
        SpeedGuards.Add(speedguard);
    }
}
