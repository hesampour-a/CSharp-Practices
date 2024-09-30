namespace EducationSystems.ConsoleApp;

internal class MenuBuilder(Dictionary<string, Action> menuItems)
{
    void PrintMenu()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            Ui.ShowMessage($"{i + 1}. {menuItems.Keys.ElementAt(i)}");
        }
        Ui.ShowMessage($"0. Exit");
    }

    int GetMenuChoice()
    {
        int choice = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            choice = Ui.GetIntegerFromUser("Enter your choice : ");
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

        int menuChice = 0;
        do
        {
            PrintMenu();
            menuChice = GetMenuChoice();
            DoAction(menuChice);
            Ui.GetStringFromUser("Press any key to continue ...");
            Console.Clear();
        }
        while (menuChice != 0);
    }

    bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }
}
