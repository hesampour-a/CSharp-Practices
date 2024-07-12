//تعداد اعدادی که میخواهد وارد کند
//بین n تا عدد max1 , max2,min

Console.WriteLine("Insert number of inputs : ");
int numberOfInputs = int.Parse(Console.ReadLine());
int index = 1;
int max1 = 0;
int max2 = 0;
int min = 0;
while (numberOfInputs >= index)
{
    Console.WriteLine("Insert number # " + index.ToString());
    int number = int.Parse(Console.ReadLine());
    if (index == 1)
    {
        max1 = number;
        max2 = number;
        min = number;
    }

    if (number > max1)
    {
        max2 = max1;
        max1 = number;
    }
    else if (number > max2)
    {
        max2 = number;
    }
    else if (number < min)
    {
        min = number;
    }
    index++;

}
Console.WriteLine("max1 : " + max1.ToString() + "  max2 : " + max2.ToString() + "  min :  " + min.ToString());

int GetnumberFromUser(string message)
{
    int? number = null;
    bool canParseToInt = false;
    while (!canParseToInt)
    {
        Console.WriteLine(message);
        canParseToInt = int.TryParse(Console.ReadLine(), out int result);
        if (result != null || result < 0)
        {
            canParseToInt = false;
            Console.WriteLine("Wrong Input");
        }
        number = result;
    }
    return number!.Value;
}