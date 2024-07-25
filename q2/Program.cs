// See https://aka.ms/new-console-template for more information


int length, width;

Console.WriteLine("Enter Length : ");

length = int.Parse(Console.ReadLine());


Console.WriteLine("Enter Width : ");

width = int.Parse(Console.ReadLine());

for (int i = 0; i < width; i++)
{
    for (int j = 0; j < length; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
Console.WriteLine();



for (int i = 0; i < width; i++)
{
    for (int j = 0; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

