//C# Functions Practices
//Practice #1
int HaveInAndOut(int number) => number + 1;
int OnlyHaveOut() => 8;
void DontHaveInAndOut()
{
    Console.WriteLine("Nothing");
}
void OnlyHaveIn(string message)
{
    Console.WriteLine(message);
}

int numberPlusOne = HaveInAndOut(5);
int number = OnlyHaveOut();
OnlyHaveIn("some thing");
DontHaveInAndOut();

//Practice #2
int PrintToOne(int number)
{
    if (number == 0)
        return number;
    Console.Write($" {number}");
    return PrintToOne(number - 1);
}

PrintToOne(10);

//Practice #3
string AddNames(params string[] names) => string.Join(" , ", names);


Console.WriteLine(AddNames("Ali", "Mohammad", "Karim", "Taha"));