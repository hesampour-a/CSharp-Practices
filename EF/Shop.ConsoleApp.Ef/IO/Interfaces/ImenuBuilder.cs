namespace Shop.ConsoleApp.Ef.IO.Interfaces;

public interface IMenuBuilder
{
    public Dictionary<string, Action> MenuItems { get; set; }
    void AddMenuItems();
    public void Show();
}