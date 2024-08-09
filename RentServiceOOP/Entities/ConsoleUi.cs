using System.Numerics;
using RentServiceOOP.Interfaces;

namespace RentServiceOOP.Entities;

public class ConsoleUi : IUi
{


    public Contract GetContract()
    {
        return new Contract
        {
            HouseId = GetIntegerFromUser("Enter HouseId:"),
            TenantId = GetIntegerFromUser("Enter TenantId:"),
            OwnerId = GetIntegerFromUser("Enter OwnerId:"),
            StartDate = GetDateTimeFromUser("Enter StartDate:"),
            EndDate = GetDateTimeFromUser("Enter EndDate:"),
            RentRate = GetBigIntegerFromUser("Enter RentRate:"),
            MortgageRate = GetBigIntegerFromUser("Enter MortgageRate:")
        };
    }

    public House GetHouse()
    {
        return new House
        {
            Address = GetStringFromUser("Enter Address:"),
            OwnerId = GetIntegerFromUser("Enter OwnerId:"),
            RentRate = GetBigIntegerFromUser("Enter RentRate:"),
            MortgageRate = GetBigIntegerFromUser("Enter mortgageRate:"),
        };

    }

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

    public User GetUser()
    {
        throw new NotImplementedException();
    }

    public DateTime GetDateTimeFromUser(string message)
    {
        Console.WriteLine(message);
        bool isDateValid = false;
        DateTime dateTime = new DateTime();
        while (!isDateValid)
        {
            isDateValid = DateTime.TryParse(Console.ReadLine(), out DateTime result);
            if (!isDateValid)
                Console.WriteLine("Please Enter a correct dateTime");

            if (isDateValid)
                dateTime = result;
        }
        return dateTime;
    }


}