string[,] Employee = new string[1, 4];

Employee[0, 0] = "name";
Employee[0, 1] = "score";
Employee[0, 2] = "sabaghe";
Employee[0, 3] = "PlusIncome";

run();


void run()
{

    while (true)
    {
        Console.WriteLine("Enter Your Choise number :");
        Console.WriteLine("1 . Add New Personel :");
        Console.WriteLine("2 . Show Personel By Id :");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                string[] newEmp = GetNewEmployeeFromUser(Employee);
                Employee = AddNewItemToEmployee(Employee, newEmp);
                Employee = CalculateIncome(Employee);
                break;
            case "2":
                int personelId = int.Parse(Console.ReadLine());
                ShowPersonelIncomePeresent(personelId);
                break;
            default:
                break;
        }
        Console.ReadLine();
    }

}


void ShowPersonelIncomePeresent(int id)
{
    Console.WriteLine(Employee[id, 3]);
}

string[,] AddNewItemToEmployee(string[,] Employees, string[] newEmployee)
{
    string[,] nEmployees = new string[Employees.GetLength(0) + 1, Employees.GetLength(1)];
    nEmployees = CopyArray(Employees, nEmployees);

    for (int i = 0; i < Employees.GetLength(1); i++)
        nEmployees[nEmployees.GetLength(0) - 1, i] = newEmployee[i];

    return nEmployees;
}

string[,] CopyArray(string[,] sourceArray, string[,] destinationArray)
{
    for (int i = 0; i < sourceArray.GetLength(0); i++)
    {
        for (int j = 0; j < sourceArray.GetLength(1); j++)
        {
            destinationArray[i, j] = sourceArray[i, j];
        }
    }
    return destinationArray;
}

string[] GetNewEmployeeFromUser(string[,] Employees)
{
    string[] newItem = new string[Employees.GetLength(1)];
    for (int i = 0; i < Employees.GetLength(1); i++)
    {
        Console.WriteLine($"insert new Employee " + Employees[0, i]);
        newItem[i] = Console.ReadLine();
    }

    return newItem;
}


string[,] CalculateIncome(string[,] EmployyesArray)
{
    for (int i = 1; i < EmployyesArray.GetLength(0); i++)
    {
        if (EmployyesArray[i, 1] == "Exelent")
        {
            EmployyesArray[i, 3] = "30";
        }
        else if (EmployyesArray[i, 1] == "Good")
        {
            EmployyesArray[i, 3] = "15";
        }
        else if (EmployyesArray[i, 1] == "Average")
        {
            EmployyesArray[i, 3] = "7";
        }
        else if (EmployyesArray[i, 1] == "Weak")
        {
            EmployyesArray[i, 3] = "0";
        }


        int sabeghe = int.Parse(EmployyesArray[i, 2]);
        if (sabeghe >= 5)
        {
            EmployyesArray[i, 3] = (int.Parse(EmployyesArray[i, 3]) + 5).ToString();
        }

    }
    return EmployyesArray;
}