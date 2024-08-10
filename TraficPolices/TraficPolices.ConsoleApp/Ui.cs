using Models.Cars;
using Models.Enums;
using Models.Roads;
using Models.SpeedGuards;
using Models.SpeedLimits;
using System.Numerics;

namespace TraficPolices.ConsoleApp;

internal static class Ui
{
    public static int GetIntegerFromUser(string message)
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
    public static BigInteger GetBigIntegerFromUser(string message)
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
    public static string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine()!;
    }
    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    static void ShowCarTypes()
    {
        var names = Enum.GetNames(typeof(CarType));
        //var values = Enum.GetValues(typeof(CarType));

        Console.WriteLine("Car Types:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + names[i]);
        }
    }
    public static Car GetCar()
    {
        ShowCarTypes();
        return new Car((CarType)GetIntegerFromUser("Enter Car Type :"), GetStringFromUser("Enter Plaque:"));
    }

    public static Road GetRoad()
    {
        string title = GetStringFromUser("Enter Road Title :");
        var speedLimits = new List<SpeedLimit>();
        var names = Enum.GetNames(typeof(CarType));
        //var values = Enum.GetValues(typeof(CarType));

        for (int i = 0; i < names.Length; i++)
        {
            ShowMessage("Enter SpeedLimit for " + (i + 1) + ": " + names[i]);

            speedLimits.Add(new SpeedLimit((CarType)i + 1, GetIntegerFromUser("Enter ValidSpeed:")));
        }
        return new Road(title, speedLimits);
    }

    public static SpeedGuard GetSpeedGuard()
    {
        return new SpeedGuard(GetStringFromUser("Enter Title :"));
    }



}
