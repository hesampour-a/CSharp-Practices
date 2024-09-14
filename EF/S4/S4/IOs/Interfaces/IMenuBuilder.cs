namespace S4.IOs.Interfaces;

public interface IMenuBuilder
{
    public Dictionary<string, Action> MenuItems { get; set; }
    void AddMenuItems();
    public void Show();
}