using System.Numerics;
using TraficPolices.ConsoleApp.Databases;

namespace TraficPolices.ConsoleApp.Entities;

public class TraficPolice()
{
    public Database Database { get; set; } = new Database(new ConsoleUi());

    Movement DeploySpeedGuard()
    {
        var speedGuard = Database.IdentifySpeedGuard();
        return speedGuard.Guard();
    }
    Penalty? CheckMovement(Movement movement)
    {
        var road = Database.Roads.Find(r => r.Id == movement.RoadId);
        var car = Database.Cars.Find(c => c.Plaque == movement.CarPlaque);
        var speedLimit = road.SpeedLimits.Find(s => s.CarType == car.CarType);
        if (speedLimit.ValidSpeed >= movement.Speed)
            return null;

        return new Penalty
        {
            CarId = car.Id,
            Amount = CalculatePenaltyAmont(movement.Speed - speedLimit.ValidSpeed)
        };

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

    public void Observe()
    {
        var penalty = CheckMovement(DeploySpeedGuard());

        if (penalty != null)
            Database.AddPenalty(penalty);

    }

    public void ShowMainMenu()
    {
        var menuItems = new Dictionary<string, Action>();
        menuItems.Add("Add New Car", Database.AddCar);
        menuItems.Add("Add New Road", Database.AddRoad);
        menuItems.Add("Add New Speed Guard", Database.AddSpeedGuard);
        menuItems.Add("Observe", Observe);
        menuItems.Add("Show total penalties for a car", Database.ShowSumOfAllPenalties);
        Menu menu = new Menu(menuItems, new ConsoleUi());
        menu.Start();

    }
}