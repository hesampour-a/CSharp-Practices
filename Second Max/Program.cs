
int sizeOfArray = GetNumberFromUser("Enter number of numbers :");

int[] numbers = new int[sizeOfArray];
int max = 0;
int secondMax = 0;
for (int i = 0; i < sizeOfArray; i++)
{
    numbers[i] = GetNumberFromUser($"Enter number #{i + 1} :");
    if (i == 0)
    {
        max = numbers[i];
        secondMax = numbers[i];
    }
    else if (numbers[i] > max)
    {
        secondMax = max;
        max = numbers[i];
    }
    else if (numbers[i] > secondMax)
    {
        secondMax = numbers[i];
    }
}
Console.WriteLine($"The second max is :{secondMax}");













int GetNumberFromUser(string message)
{
    int? number = null;
    bool canParseToInt = false;
    while (!canParseToInt)
    {
        Console.WriteLine(message);
        canParseToInt = int.TryParse(Console.ReadLine(), out int result);
        if (!canParseToInt || result < 0)
        {
            canParseToInt = false;
            Console.WriteLine("Wrong Input");
        }
        number = result;
    }
    return number!.Value;
}