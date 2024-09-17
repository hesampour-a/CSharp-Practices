using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO;

public class MenuBuilder(
    Dictionary<string, Action> menuItems,
    IUi ui,
    string exitMessage = "Exit")
{
    private void PrintMenu()
    {
        for (var i = 0; i < menuItems.Count; i++)
            ui.ShowMessage($"{i + 1}. {menuItems.Keys.ElementAt(i)}");

        ui.ShowMessage($"0. {exitMessage}");
    }

    private int GetMenuChoice()
    {
        var choice = 0;
        var validChoice = false;
        while (!validChoice)
        {
            choice = ui.GetIntegerFromUser("Enter your choice : ");
            validChoice = ValidateUserChoice(choice);
        }

        return choice;
    }

    private void DoAction(int choice)
    {
        if (choice == 0)
            return;
        menuItems.Values.ElementAt(choice - 1).Invoke();
    }

    public void Start()
    {
        var menuChoice = 0;
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
            catch (Exception e)
            {
                ui.ShowMessage(e.Message);
            }


            ui.GetStringFromUser("Press any key to continue ...");
            Console.Clear();
        } while (menuChoice != 0);
    }

    private bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }
}