using Models.Roads;
using Models.TraficPolices;
using TraficPolices.ConsoleApp.Interfaces;
using TraficPolices.ConsoleApp.Uis;

namespace TraficPolices.ConsoleApp.Menus;

internal class TraficPoliceMenu(TraficPolice traficPolice,IUi ui)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();

    void AddMenuItems()
    {
        MenuItems.Add("Add Car", AddCar);
        MenuItems.Add("Add Road", AddRoad);
        MenuItems.Add("Add SpeedGuard", AddSpeedGuard);
        MenuItems.Add("Show total penalty for plaque", ShowPenaltyForPlaque);
        MenuItems.Add("Show Roads with speed limit under 60", ShowRoadsWithSpeedLimitUnder);

    }

    void AddCar()
    {
        traficPolice.Database.RegisterCar(ui.GetCar());
    }
    void AddRoad()
    {
        traficPolice.Database.RegisterRoad(ui.GetRoad());
    }
    void AddSpeedGuard()
    {
        traficPolice.Database.RegisterSpeedGuard(ui.GetSpeedGuard());
    }
    void ShowPenaltyForPlaque()
    {
        ui.ShowMessage((traficPolice.TotalPenaltyForPlaque(
            ui.GetStringFromUser("Enter Plaque :"))).ToString());
    }
    void ShowRoadsWithSpeedLimitUnder()
    {
       var roads = traficPolice.GetRoadsWithSpeedLimitForTrucks();
        if (roads.Count == 0)
        {
            ui.ShowMessage("There is no road with this limit");
            return;
        }
        roads.ForEach(road => {
            PrintRoadDto(road);
        });
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems,ui).Start();
    }
    
    void PrintRoadDto(RoadDto dto)
    {
        ui.ShowMessage(dto.StartPoint);
        ui.ShowMessage(dto.EndPoint);
        ui.ShowMessage("***");
    }
    
}
