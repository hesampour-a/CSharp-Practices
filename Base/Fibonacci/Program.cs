//Fibonacci
using System.Numerics;

int indexOfFibonacci = GetNumberFromUser("insert number : ");

BigInteger twoNumbersBack = 0;
BigInteger oneNumberBack = 1;
int index = 1;
while (index < indexOfFibonacci)
{
    BigInteger temp = oneNumberBack;
    oneNumberBack = oneNumberBack + twoNumbersBack;
    twoNumbersBack = temp;
    index++;
}

Console.WriteLine("# " + index.ToString() + " Of Fibonacci is : " + oneNumberBack.ToString());






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