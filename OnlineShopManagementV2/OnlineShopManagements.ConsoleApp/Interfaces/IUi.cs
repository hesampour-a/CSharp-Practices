namespace OnlineShopManagements.ConsoleApp.Interfaces;

public interface IUi
{
    public string GetString(string message);
    public int GetInt(string message);
    public double GetDouble(string message);
    public void ShowMessage(string message);
}
