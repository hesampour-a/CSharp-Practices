namespace Common.Entities;

public class Menu(Dictionary<string, Action> menuItems)
{
    void PrintMenu()
    {
        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems.Keys.ElementAt(i)}");
        }
        Console.WriteLine($"0. Exit");


    }

    int GetMenuChoice()
    {
        int choice = 0;
        bool validChoice = false;
        while (!validChoice)
        {
            Console.WriteLine("Enter your choice : ");
            choice = int.Parse(Console.ReadLine()!);
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
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Console.Clear();
        }
        while (menuChice != 0);
    }

    bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }

}
