Console.WriteLine("Ax^2 + Bx + C = 0");
double a, b, c;


Console.WriteLine("Enter A  :");
a = double.Parse(Console.ReadLine());


Console.WriteLine("Enter B  :");
b = double.Parse(Console.ReadLine());

Console.WriteLine("Enter C  :");
c = double.Parse(Console.ReadLine());


double delta = Math.Pow(b, 2) - (4 * a * c);

if (delta > 0)
{
    Console.WriteLine($"First Result : {(-b + Math.Sqrt(delta)) / (2 * a)}");
    Console.WriteLine($"Second Result : {(-b - Math.Sqrt(delta)) / (2 * a)}");
}
else if (delta == 0)
{
    Console.WriteLine($"First Result : {(-b + Math.Sqrt(delta)) / (2 * a)}");

}
else
{
    Console.WriteLine("There is no answer");
}