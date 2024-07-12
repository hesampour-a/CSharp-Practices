int CarsNumber = GetNumberFromUser("Enter number of cars: ");

string[,] cars = new string[CarsNumber, 2];

for (int i = 0; i < CarsNumber; i++)
{
    int index = i + 1;
    Console.WriteLine($"Enter car #{index} name : ");
    cars[i, 0] = Console.ReadLine();

    Console.WriteLine($"Enter car #{index}  color : ");
    cars[i, 1] = Console.ReadLine();
}


Console.WriteLine("*****************");


for (int i = 0; i < cars.GetLength(0); i++)
{
    Console.WriteLine(cars[i, 0] + " " + cars[i, 1]);
}



// for (int i = 0; i < cars.GetLength(0); i++)
// {
//     for (int j = 0; j < cars.GetLength(1); j++)
//     {
//         Console.Write(cars[i, j] + " ");

//     }
//     Console.WriteLine("");
// }



int GetNumberFromUser(string message)
{
    int? number = null;
    bool canParseToInt = false;
    while (!canParseToInt)
    {
        Console.WriteLine(message);
        canParseToInt = int.TryParse(Console.ReadLine(), out int result);
        if (!canParseToInt || result <= 0)
        {
            canParseToInt = false;
            Console.WriteLine("Wrong Input");
        }
        number = result;
    }
    return number!.Value;
}