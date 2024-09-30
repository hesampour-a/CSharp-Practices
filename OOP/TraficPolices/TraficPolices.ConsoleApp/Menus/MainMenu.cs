using Models.TraficPolices;
using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Menus;

internal class MainMenu(TraficPolice traficPolice,IUi ui)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();


    void AddMenuItems()
    {
        MenuItems.Add("Trafic Police Menu", ShowTraficPoliceMenu);
        MenuItems.Add("SpeedGuard Menu",ShowSpeedGuardMenu);
    }

    void ShowTraficPoliceMenu()
    {
        new TraficPoliceMenu(traficPolice,ui).Show();
    }
    void ShowSpeedGuardMenu()
    {
        new SpeedGuardMenu(traficPolice,ui).Show();
    }




    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems,ui).Start();
    }



}
