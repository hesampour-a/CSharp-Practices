using Models.SpeedGuards;
using Models.TraficPolices;

namespace TraficPolices.ConsoleApp.Menus;

internal class SpeedGuardMenu(TraficPolice traficPolice)
{
    private Dictionary<string, Action> MenuItems { get; set; } = new Dictionary<string, Action>();
    void AddItemsToMenu()
    {
        MenuItems.Add("Report Movement", ReportMovement);

    }

    void ReportMovement()
    {
        traficPolice.Monitor(SpeedGuard.RecordMovement(
            Ui.GetIntegerFromUser("Enter Road ID :"),
            Ui.GetStringFromUser("Enter Car Plaque :"),
            Ui.GetIntegerFromUser("Enter Speed :")));
    }

    public void Show()
    {
        AddItemsToMenu();
        new Menu(MenuItems).Start();
    }
}
