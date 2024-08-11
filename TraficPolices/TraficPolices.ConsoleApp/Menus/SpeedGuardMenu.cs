using Models.SpeedGuards;
using Models.TraficPolices;
using TraficPolices.ConsoleApp.Interfaces;
using TraficPolices.ConsoleApp.Uis;

namespace TraficPolices.ConsoleApp.Menus;

internal class SpeedGuardMenu(TraficPolice traficPolice,IUi ui)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();
    void AddItemsToMenu()
    {
        MenuItems.Add("Report Movement", ReportMovement);

    }

    void ReportMovement()
    {
        traficPolice.Monitor(SpeedGuard.RecordMovement(
            ui.GetIntegerFromUser("Enter Road ID :"),
            ui.GetStringFromUser("Enter Car Plaque :"),
            ui.GetIntegerFromUser("Enter Speed :")));
    }

    public void Show()
    {
        AddItemsToMenu();
        new MenuBuilder(MenuItems,ui).Start();
    }
}
