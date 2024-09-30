namespace TraficPolices.ConsoleApp.Interfaces;

public interface IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; }
    void AddMenuItems();
    public void Show();
}
