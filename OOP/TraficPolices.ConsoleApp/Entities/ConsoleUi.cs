using System.Numerics;
using TraficPolices.ConsoleApp.Enums;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class ConsoleUi : IUi
{
    public int GetIntegerFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        int number = 0;
        while (!isNumberValid)
        {
            isNumberValid = int.TryParse(Console.ReadLine(), out int result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }
        return number;
    }

    public BigInteger GetBigIntegerFromUser(string message)
    {
        Console.WriteLine(message);
        bool isNumberValid = false;
        BigInteger number = 0;
        while (!isNumberValid)
        {
            isNumberValid = BigInteger.TryParse(Console.ReadLine(), out BigInteger result);
            if (!isNumberValid)
                Console.WriteLine("Please Enter a correct number");

            if (isNumberValid)
                number = result;
        }
        return number;
    }

    public string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    void ShowCarTypes()
    {
        var names = Enum.GetNames(typeof(CarType));
        //var values = Enum.GetValues(typeof(CarType));

        Console.WriteLine("Car Types:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + names[i]);
        }
    }

    public Car GetCar()
    {
        ShowCarTypes();

        return new Car((CarType)GetIntegerFromUser(" "), GetStringFromUser("Enter Plaque:"));

    }

    public Movement GetMovement()
    {
        return new Movement
        {
            RoadId = GetIntegerFromUser("Enter RoadId:"),
            CarPlaque = GetStringFromUser("Enter CarPlaque:"),
            Speed = GetIntegerFromUser("Enter Speed:")
        };
    }

    public Road GetRoad()
    {
        ShowCarTypes();
        var speedLimits = new List<SpeedLimit>();
        var names = Enum.GetNames(typeof(CarType));
        //var values = Enum.GetValues(typeof(CarType));

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine("Enter SpeedLimit for " + (i + 1) + ": " + names[i]);

            speedLimits.Add(new SpeedLimit
            {
                CarType = (CarType)i + 1,
                ValidSpeed = GetIntegerFromUser("Enter ValidSpeed:")
            });
        }

        return new Road
        {
            SpeedLimits = speedLimits
        };
    }
    public void Clear()
    {
        Console.Clear();
    }


}