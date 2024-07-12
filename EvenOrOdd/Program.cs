Print($"The Number Is {GetNumberType(GetNumber())}");




string GetNumberType(int number) => number % 2 == 0 ? "Even" : "Odd";

void Print(string message)
{
    Console.WriteLine(message);
}

int GetNumber() => 9;