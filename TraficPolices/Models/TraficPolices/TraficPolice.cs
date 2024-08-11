using Models.Databases;
using Models.Mapper;
using Models.Movements;
using Models.Penalties;
using Models.Roads;
using System.Numerics;

namespace Models.TraficPolices;

public class TraficPolice
{
    public Database Database { get; set; } = new();

    public BigInteger TotalPenaltyForPlaque(string plaque)
    {
        var car = Database.Cars.First(c => c.Plaque == plaque)
            ?? throw new Exception("plaque not found");
        BigInteger sum = 0;
        car.Penalties.ForEach(p => sum += p.Amount);
        return sum;
    }

    public void Monitor(Movement movement)
    {
        var road = Database.Roads.Find(r => r.Id == movement.RoadId)
            ?? throw new Exception("Road Not Found");
        var car = Database.Cars.Find(c => c.Plaque == movement.CarPlaque)
            ?? throw new Exception("Car Not Found");
        var speedLimit = road.SpeedLimits.Find(s => s.CarType == car.Type);

        if (speedLimit!.ValidSpeed >= movement.Speed)
            return;

        car.Penalties.Add(new Penalty(CalculatePenaltyAmont(movement.Speed - speedLimit.ValidSpeed)));


    }

    BigInteger CalculatePenaltyAmont(int overSpeed)
    {
        switch (overSpeed)
        {
            case <= 10:
                return 100000;


            case <= 20:
                return 150000;


            case <= 30:
                return 200000;

            default:
                return 400000;
        }
    }

    public List<RoadDto> GetRoadsWithSpeedLimitForTrucks(int speedLimit = 60)
    {
        var roads = new List<RoadDto>();
        foreach (var road in Database.Roads)
        {
            if (road.SpeedLimits.Any(_ => _.CarType == Enums.CarType.Truck && _.ValidSpeed <= speedLimit))
                roads.Add(road.CreateRoadDto());
        }

        return roads;
    }




}
