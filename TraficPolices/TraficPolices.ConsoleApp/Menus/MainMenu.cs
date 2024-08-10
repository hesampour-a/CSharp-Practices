using Models.TraficPolices;

namespace TraficPolices.ConsoleApp.Menus;

internal class MainMenu(TraficPolice traficPolice)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();


    void AddMenuItems()
    {
        MenuItems.Add("Trafic Police Menu", ShowTraficPoliceMenu);
        MenuItems.Add("SpeedGuard Menu",ShowSpeedGuardMenu);
    }

    void ShowTraficPoliceMenu()
    {
        new TraficPoliceMenu(traficPolice).Show();
    }
    void ShowSpeedGuardMenu()
    {
        new SpeedGuardMenu(traficPolice).Show();
    }




    public void Show()
    {
        AddMenuItems();
        new Menu(MenuItems).Start();
    }



}
