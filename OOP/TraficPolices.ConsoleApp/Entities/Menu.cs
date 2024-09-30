using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities;

public class Menu(Dictionary<string, Action> menuItems, IUi ui)
{
    void PrintMenu()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            ui.ShowMessage($"{i + 1}. {menuItems.Keys.ElementAt(i)}");
        }
        ui.ShowMessage($"0. Exit");
    }

    int GetMenuChoice()
    {
        int choice = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            choice = ui.GetIntegerFromUser("Enter your choice : ");
            validChoice = ValidateUserChoice(choice);
        }
        return choice;
    }

    void DoAction(int choice)
    {
        if (choice == 0)
            return;

        menuItems.Values.ElementAt(choice - 1)();
    }

    public void Start()
    {
        ui.Clear();
        int menuChice = 0;
        do
        {
            PrintMenu();
            menuChice = GetMenuChoice();
            DoAction(menuChice);
            ui.GetStringFromUser("Press any key to continue ...");
            ui.Clear();
        }
        while (menuChice != 0);
    }

    bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }

}
