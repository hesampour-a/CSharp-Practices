namespace Tickets.ConsoleApp.Interfaces
{
    public interface IConsoleUi
    {
        void Clear();
        DateTime GetDate(string message);
        double GetDouble(string message);
        int GetInt(string message);
        string GetString(string message);
        void Show(string message);
    }
}