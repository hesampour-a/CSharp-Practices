namespace S4.IOs.Interfaces;

public interface IUi
{
    public void ShowMessage(string message);
    public int GetIntegerFromUser(string message);
    public string GetStringFromUser(string message);
}