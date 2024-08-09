using TraficPolices.ConsoleApp.Entities;

namespace TraficPolices.ConsoleApp.Menu;

public class AddCar
{
    public static void Run(TraficPolice traficPolice)
    {
        traficPolice.Database.AddCar();
    }
}