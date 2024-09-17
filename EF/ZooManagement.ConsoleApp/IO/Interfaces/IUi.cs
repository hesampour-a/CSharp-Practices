namespace ZooManagement.ConsoleApp.IO.Interfaces;

public interface IUi
{
    public void ShowMessage(string message);
    public int GetIntegerFromUser(string message);
    public decimal GetDecimalFromUser(string message);
    public string GetStringFromUser(string message);
}