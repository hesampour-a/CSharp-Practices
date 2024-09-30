namespace OnlineShopManagements.ConsoleApp.Interfaces;

public interface IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; }

    void AddItemsToDictionary();
    void Show();
}
