using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
        throw new System.NotImplementedException();
    }
}