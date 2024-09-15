using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.IO.Interfaces;

namespace BuildingManagement.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
       MenuItems.Add("Show Block Menu",ShowBlockMenu);
       MenuItems.Add("Show Floor Menu",ShowFloorMenu);
       MenuItems.Add("Show Unit Menu",ShowUnitMenu);
       MenuItems.Add("Show Cost Menu",ShowCostMenu);
     
    }

    private void ShowBlockMenu()
    {
       new BlockMenu(ui,dbContext).Show();
    }

    private void ShowFloorMenu()
    {
        new FloorMenu(ui,dbContext).Show();
    }

    private void ShowUnitMenu()
    {
        new UnitMenu(ui,dbContext).Show();
    }

    private void ShowCostMenu()
    {
        new CostMenu(ui,dbContext).Show();
    }
}