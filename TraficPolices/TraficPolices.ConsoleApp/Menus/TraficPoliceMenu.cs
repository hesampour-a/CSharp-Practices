using Models.TraficPolices;

namespace TraficPolices.ConsoleApp.Menus;

internal class TraficPoliceMenu(TraficPolice traficPolice)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();

    void AddMenuItems()
    {
        MenuItems.Add("Add Car", AddCar);
        MenuItems.Add("Add Road", AddRoad);
        MenuItems.Add("Add SpeedGuard", AddSpeedGuard);
        MenuItems.Add("Show total penalty for plaque", ShowPenaltyForPlaque);

    }

    void AddCar()
    {
        traficPolice.Database.RegisterCar(Ui.GetCar());
    }
    void AddRoad()
    {
        traficPolice.Database.RegisterRoad(Ui.GetRoad());
    }
    void AddSpeedGuard()
    {
        traficPolice.Database.RegisterSpeedGuard(Ui.GetSpeedGuard());
    }
    void ShowPenaltyForPlaque()
    {
        Ui.ShowMessage((traficPolice.TotalPenaltyForPlaque(Ui.GetStringFromUser("Enter Plaque :"))).ToString());
    }

    public void Show()
    {
        AddMenuItems();
        new Menu(MenuItems).Start();
    }
}
