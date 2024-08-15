﻿using TraficPolices.ConsoleApp.Interfaces;
using TraficPolices.ConsoleApp.Uis;

namespace TraficPolices.ConsoleApp;

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

        menuItems.Values.ElementAt(choice - 1)();
    }

    public void Start()
    {

        int menuChoice = 0;
        do
        {
            PrintMenu();
            menuChoice = GetMenuChoice();
            DoAction(menuChoice);
            ui.GetStringFromUser("Press any key to continue ...");
            Console.Clear();
        }
        while (menuChoice != 0);
    }

    bool ValidateUserChoice(int choice)
    {
        return choice >= 0 && choice <= menuItems.Count;
    }

}