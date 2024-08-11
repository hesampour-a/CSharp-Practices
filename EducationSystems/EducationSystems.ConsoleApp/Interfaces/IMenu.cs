namespace EducationSystems.ConsoleApp.Interfaces;

internal interface IMenu
{
    public Dictionary<string, Action> MenuItems { get; set; }
    void AddMenuItems();
    public void Show();
}
