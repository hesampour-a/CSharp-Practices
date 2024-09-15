using Library.Ef.ConsoleApp.EfPersistence;
using Library.Ef.ConsoleApp.IO.Interfaces;

namespace Library.Ef.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
        MenuItems.Add("Show Books Menu",ShowBooksMenu);
    }

    private void ShowBooksMenu()
    {
        new BookMenu(ui).Show();
    }
}