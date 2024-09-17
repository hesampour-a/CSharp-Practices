namespace Esmaeel.ConsoleApp.IO.Interfaces;

public abstract class MenuStructure(IUi ui)
{
    protected virtual string ExitMessageMenu { get;  } = "Exit";
    protected Dictionary<string, Action> MenuItems { get; set; } = [];

    protected abstract void AddMenuItems();
    

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui,ExitMessageMenu).Start();
    }
}