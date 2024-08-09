using System.Numerics;
using TraficPolices.ConsoleApp.Entities;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Databases;

public class Database(IUi ui)
{
    public List<Car> Cars { get; set; } = [];
    public List<Road> Roads { get; set; } = [];
    public List<SpeedGuard> SpeedGuards { get; set; } = [];
    public List<Penalty> Penalties { get; set; } = [];

    int CalculateNewItemId<T>(List<T> list) where T : HasIdClass
    {
        return list.Count > 0 ? list.Last().Id + 1 : 1;
    }
    public void AddCar()
    {
        var newCar = ui.GetCar();
        newCar.Id = CalculateNewItemId(Cars);
        Cars.Add(newCar);
    }

    public void AddRoad()
    {
        var newRoad = ui.GetRoad();
        newRoad.Id = CalculateNewItemId(Roads);
        Roads.Add(newRoad);
    }

    public void AddSpeedGuard()
    {
        var newSpeedGuard = new SpeedGuard(ui);
        newSpeedGuard.Id = CalculateNewItemId(SpeedGuards);
        SpeedGuards.Add(newSpeedGuard);
    }

    public void AddPenalty(string carPlaque, int amount)
    {

        var newPenalty = new Penalty
        {
            CarId = Cars.Find(c => c.Plaque == carPlaque).Id,
            Amount = amount
        };

        Penalties.Add(newPenalty);
    }

    public BigInteger SumOfPenaltiesForPlaque(string carPlaque)
    {
        BigInteger sum = 0;
        var penalties = Penalties.FindAll(p => p.CarId == Cars.Find(c => c.Plaque == carPlaque).Id);
        foreach (var penalty in penalties)
        {
            sum += penalty.Amount;
        }
        return sum;
    }
    // public void ShowMainMenu()
    // {
    //     var menuItems = new Dictionary<string, Action>();
    //     menuItems.Add("Add New Car", AddCar);
    //     menuItems.Add("Add New Road", AddRoad);
    //     menuItems.Add("Add New Speed Guard", AddSpeedGuard);
    //     menuItems.Add("Add Penalty", AddPenalty);
    //     menuItems.Add("Show total penalties for a car", ShowSumOfAllPenalties);
    //     Menu menu = new Menu(menuItems, ui);
    //     menu.Start();

    // }
    public void AddPenalty(Penalty penalty)
    {
        Penalties.Add(penalty);
    }
    public SpeedGuard IdentifySpeedGuard()
    {
        var speedGuard = new SpeedGuard(ui);
        do
        {
            speedGuard = SpeedGuards.Find(s => s.Id == ui.GetIntegerFromUser("Hey Speed Guard, Enter your ID: "));

        } while (speedGuard == null);
        return speedGuard;
    }
    public void ShowSumOfAllPenalties()
    {
        var car = ui.GetStringFromUser("Enter car plaque: ");
        ui.ShowMessage($"Sum of penalties for {car} is: {SumOfPenaltiesForPlaque(car)}");
    }

}