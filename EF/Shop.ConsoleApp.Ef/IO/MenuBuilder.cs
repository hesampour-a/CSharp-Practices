using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;

namespace Shop.ConsoleApp.Ef.IO;

public class MenuBuilder(Dictionary<string, Action> menuItems, IUi ui, string exitMessage = "Exit")
{
    void PrintMenu()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            ui.ShowMessage($"{i + 1}. {menuItems.Keys.ElementAt(i)}");
        }

        ui.ShowMessage($"0. {exitMessage}");
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
        menuItems.Values.ElementAt(choice - 1).Invoke();
    }

    public void Start()
    {
        int menuChoice = 0;
        do
        {
            PrintMenu();
            menuChoice = GetMenuChoice();
            try
            {
                DoAction(menuChoice);
            }
            catch (NotFoundException e)
            {
                ui.ShowMessage(e.Message);
            }
            


            ui.GetStringFromUser("Press any key to continue ...");
            Console.Clear();
        } while (menuChoice != 0);
    }

    bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }
}