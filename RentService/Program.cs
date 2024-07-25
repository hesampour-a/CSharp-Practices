using System.Numerics;

DateTime CurrentDate = DateTime.Now;

Console.WriteLine(CurrentDate);

string[,] Users = new string[3, 3];
Users[0, 0] = "Name";
Users[0, 1] = "PhoneNumber";
Users[0, 2] = "FamilyPopulation";

string[,] Houses = new string[2, 6];
Houses[0, 0] = "OwnerId";
Houses[0, 1] = "Address";
Houses[0, 2] = "Meterage";
Houses[0, 3] = "MortgageRate"; //رهن
Houses[0, 4] = "RentRate";
Houses[0, 5] = "Capacity";

string[,] Contracts = new string[2, 7];
Contracts[0, 0] = "HouseId";
Contracts[0, 1] = "TenantId";
Contracts[0, 2] = "StartDate";
Contracts[0, 3] = "EndDate";
Contracts[0, 4] = "MortgageRate";
Contracts[0, 5] = "RentRate";
Contracts[0, 6] = "IsPaidOff";

string[,] Incomes = new string[1, 2];
Incomes[0, 0] = "ContractId";
Incomes[0, 1] = "Amount";

Contracts[1, 0] = "1";
Contracts[1, 1] = "1";
Contracts[1, 2] = "25/04/1402";
Contracts[1, 3] = "25/04/1404";
Contracts[1, 4] = "15000000";
Contracts[1, 5] = "15000000";
Contracts[1, 6] = "false";

Houses[1, 0] = "2";
Houses[1, 1] = "Shz";
Houses[1, 2] = "120";
Houses[1, 3] = "20000000";
Houses[1, 4] = "1000000";
Houses[1, 5] = "3";

Users[1, 0] = "Ali";
Users[1, 1] = "123456789";
Users[1, 2] = "3";

Users[2, 0] = "Ahmed";
Users[2, 1] = "123456789";
Users[2, 2] = "2";

Run();

void Run()
{
    bool continiue = true;
    while (continiue)
    {

        Print("1. Add New Contract");
        Print("2. Add New House");
        Print("3. Add New User");
        Print("4. Show All Contracts");
        Print("5. Show All Houses");
        Print("6. Show All Users");
        Print("7. Search House By Address");
        Print("8. Search House By Meterage");
        Print("9. Search House By Mortgage Rate");
        Print("10. Search House By Rent Rate");
        Print("11. Income Report");
        Print("12. Exit");

        int choice = GetNumberFromUser("Insert Your Choice Number :");

        switch (choice)
        {
            case 1:
                string[] newContract = GetNewItemFromUser(Contracts, "Contract", ContractValidator);
                Contracts = AddNewItemToArray(Contracts, newContract);
                Incomes = AddIncomeFromLastContract(Contracts, Incomes);
                break;
            case 2:
                string[] newHouse = GetNewItemFromUser(Houses, "House", HouseValidator);
                Houses = AddNewItemToArray(Houses, newHouse);
                break;
            case 3:
                string[] newUser = GetNewItemFromUser(Users, "User", null);
                Users = AddNewItemToArray(Users, newUser);
                break;
            case 4:
                ShowAllItems(Contracts, "Contract");
                break;
            case 5:
                ShowAllItems(Houses, "House");
                break;
            case 6:
                ShowAllItems(Users, "User");
                break;
            case 7:
                string name = GetStringFromUser("Insert Address or a part of Address :");
                SearchHouseByAddress(Houses, name);
                break;
            case 8:
                BigInteger meterage = GetNumberFromUser("Insert Meterage :");
                SearchHouseByMeterage(Houses, meterage);
                break;
            case 9:
                BigInteger mortgageRate = GetNumberFromUser("Insert Mortgage Rate :");
                SearchHouseByMortgageRate(Houses, mortgageRate);
                break;
            case 10:
                BigInteger rentRate = GetNumberFromUser("Insert Mortgage Rate :");
                SearchHouseByRentRate(Houses, rentRate);
                break;
            case 11:
                ShowAllItems(Incomes, "Income");
                break;
            case 12:
                continiue = false;
                break;
            default:
                break;
        }
        Print("Press Any Key To Continue");
        Console.ReadLine();
    }

}



void ShowAllItems(string[,] Items, string ItemName)
{
    if (Items.Length <= 1)
    {
        Print($"there is no {ItemName}");
    }
    for (int i = 1; i < Items.GetLength(0); i++)
    {
        Console.Write($"{ItemName} # " + i + " : ");
        for (int j = 0; j < Items.GetLength(1); j++)
        {
            Console.Write(Items[0, j] + " : " + Items[i, j] + "  * ");
        }
        Console.WriteLine();
    }
    return;
}



string[,] AddNewItemToArray(string[,] Items, string[] newItem)
{
    string[,] newItems = new string[Items.GetLength(0) + 1, Items.GetLength(1)];
    newItems = CopyArray(Items, newItems);

    for (int i = 0; i < Items.GetLength(1); i++)
        newItems[newItems.GetLength(0) - 1, i] = newItem[i];

    return newItems;
}

string[] GetNewItemFromUser(string[,] Items, string ItemName, Func<string[], bool>? Validator)
{
    string[] newItem = new string[Items.GetLength(1)];
    bool IsDataValid = false;
    while (!IsDataValid)
    {
        for (int i = 0; i < Items.GetLength(1); i++)
            newItem[i] = GetStringFromUser($"insert new {ItemName} " + Items[0, i]);

        IsDataValid = Validator == null ? true : Validator(newItem);

        if (!IsDataValid)
            Print("Data is not valid");

    }

    return newItem;
}


string GetStringFromUser(string message)
{
    bool trueText = false;
    string inputText = "";
    while (!trueText)
    {
        Print(message);
        inputText = Console.ReadLine()!;
        trueText = true;

        if (inputText == "")
        {
            Print("Enter a correct text");
            trueText = false;
        }
    }

    return inputText!;
}


string[,] CopyArray(string[,] sourceArray, string[,] destinationArray)
{
    if (destinationArray.Length < sourceArray.Length)
    {
        Print("destination array is not large enough");
        return sourceArray;
    }
    for (int i = 0; i < sourceArray.GetLength(0); i++)
    {
        for (int j = 0; j < sourceArray.GetLength(1); j++)
        {
            destinationArray[i, j] = sourceArray[i, j];
        }
    }
    return destinationArray;
}


bool HouseValidator(string[] newItem)
{
    BigInteger.TryParse(newItem[3], out BigInteger mortgageRate);

    if (mortgageRate > 30000000)
    {
        Print("MortgageRate must be less than 30 Million");
        return false;
    }
    BigInteger.TryParse(newItem[4], out BigInteger rentRate);

    if (rentRate > 2000000)
    {
        Print("RentRate must be less than 2 Million");
        return false;
    }
    return true;

}



bool ContractValidator(string[] newContractItem)
{

    string[] house = new string[Houses.GetLength(1)];
    for (int i = 0; i < Houses.GetLength(1); i++)
        house[i] = Houses[int.Parse(newContractItem[0]), i];


    DateTime NewContractStartDate = DateTime.Parse(newContractItem[2]);
    DateTime NewContractEndDate = DateTime.Parse(newContractItem[2]);

    if (NewContractStartDate < CurrentDate)
    {
        Print("Contract start date must be after current date");
        return false;
    }
    if (NewContractEndDate < NewContractStartDate)
    {
        Print("Contract end date must be after start date");
        return false;
    }

    int tenantFamilyPopulation = int.Parse(Users[int.Parse(newContractItem[1]), 2]);
    int houseCapacity = int.Parse(house[5]);

    if (tenantFamilyPopulation > houseCapacity)
    {
        Print("Family Population must not be grater than House capacity");
        return false;
    }



    for (int k = 0; k < Contracts.GetLength(0); k++)
    {
        if (Contracts[k, 1] == newContractItem[1])  //TenantId
        {
            if (Contracts[k, 6] == "false")             //IsPaidOff
            {
                Print($"User Must pay off Contract #{k} first");
                return false;
            }
        }
    }

    int newContractMortgageRate = int.Parse(newContractItem[4]);
    int houseMortgageRate = int.Parse(house[3]);
    if (newContractMortgageRate > houseMortgageRate)
    {
        Print("Contract Mortgage rate must be less than house Mortgage rate");
        return false;
    }


    int newContractRentRate = int.Parse(newContractItem[5]);
    int houseRentRate = int.Parse(house[4]);
    if (newContractRentRate > houseRentRate)
    {
        Print("Contract rent rate must be less than house rent rate");
        return false;
    }


    for (int j = 0; j < Contracts.GetLength(0); j++)
    {
        if (newContractItem[0] == Contracts[j, 0])
        {
            if (IsBetweenDate(NewContractStartDate, DateTime.Parse(Contracts[j, 2]), DateTime.Parse(Contracts[j, 3])) || IsBetweenDate(NewContractEndDate, DateTime.Parse(Contracts[j, 2]), DateTime.Parse(Contracts[j, 3])))
            {
                Print("House Is Not Available in this time");
                return false;
            }
        }
    }
    return true;
}

bool IsBetweenDate(DateTime input, DateTime date1, DateTime date2) => (input >= date1 && input <= date2);


int GetNumberFromUser(string message)
{
    int? number = null;
    bool canParseToInt = false;
    while (!canParseToInt)
    {
        Print(message);
        canParseToInt = int.TryParse(Console.ReadLine(), out int result);
        if (!canParseToInt || result < 0)
        {
            canParseToInt = false;
            Print("Wrong Input");
        }
        number = result;
    }
    return number!.Value;
}


void SearchHouseByAddress(string[,] Items, string name)
{
    bool found = false;
    for (int i = 0; i < Items.GetLength(0); i++)
    {
        if (Items[i, 1].Contains(name))
        {
            found = true;
            ShowItemById(i, Items);
        }
    }
    if (!found)
        Print("Not found");
}

void ShowItemById(int itemId, string[,] Items)
{
    Console.Write("Item # " + itemId + " : ");
    for (int j = 0; j < Items.GetLength(1); j++)
        Console.Write(Items[0, j] + " : " + Items[itemId, j] + "  *");

    Console.WriteLine();
}

void SearchHouseByMeterage(string[,] Items, BigInteger meterage)
{
    bool found = false;

    for (int i = 1; i < Items.GetLength(0); i++)
    {
        if (IsNumberInRange(meterage, BigInteger.Parse(Items[i, 2]) - 20, BigInteger.Parse(Items[i, 2]) + 20))
        {
            found = true;
            ShowItemById(i, Items);
        }
    }
    if (!found)
        Print("Not found");

}

void SearchHouseByMortgageRate(string[,] Items, BigInteger mortgageRate)
{
    bool found = false;
    for (int i = 1; i < Items.GetLength(0); i++)
    {
        if (IsNumberInRange(mortgageRate, BigInteger.Parse(Items[i, 3]) - 5000000, BigInteger.Parse(Items[i, 3]) + 5000000))
        {
            found = true;
            ShowItemById(i, Items);
        }
    }
    if (!found)
        Print("Not found");

}

void SearchHouseByRentRate(string[,] Items, BigInteger rentRate)
{
    bool found = false;
    for (int i = 1; i < Items.GetLength(0); i++)
    {
        if (IsNumberInRange(rentRate, BigInteger.Parse(Items[i, 4]) - 1000000, BigInteger.Parse(Items[i, 4]) + 1000000))
        {
            found = true;
            ShowItemById(i, Items);
        }
    }
    if (!found)
        Print("Not found");

}



bool IsNumberInRange(BigInteger number, BigInteger min, BigInteger max) => ((number - max) * (number - min) <= 0);



string[,] AddIncomeFromLastContract(string[,] Contracts, string[,] Incomes)
{

    string[,] newIncomes = new string[Incomes.GetLength(0) + 1, Incomes.GetLength(1)];
    newIncomes = CopyArray(Incomes, newIncomes);


    newIncomes[newIncomes.GetLength(0) - 1, 0] = (Contracts.GetLength(0) - 1).ToString();
    newIncomes[newIncomes.GetLength(0) - 1, 1] = (int.Parse(Contracts[Contracts.GetLength(0) - 1, 5]) * 1 / 100).ToString();

    return newIncomes;
}

void Print(string message)
{
    Console.WriteLine(message);
}