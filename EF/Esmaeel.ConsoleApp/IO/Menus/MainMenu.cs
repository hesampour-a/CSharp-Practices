using Esmaeel.ConsoleApp.EfPersistence;
using Esmaeel.ConsoleApp.IO.Interfaces;

namespace Esmaeel.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
      MenuItems.Add("Show User Menu",ShowUserMenu);
    }

    private void ShowUserMenu()
    {
       new UserMenu(dbContext, ui).Show();
    }

   
}