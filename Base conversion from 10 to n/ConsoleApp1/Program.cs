//تبدیل مبنا از 10 به n
Console.WriteLine("insert number:");
int number = int.Parse(Console.ReadLine());

Console.WriteLine("insert base:");
int baseNumber = int.Parse(Console.ReadLine());

int index = 0;

List<int> result = new();

int remained = 0;

while (number >= baseNumber)
{
    remained = number % baseNumber;
    number = number / baseNumber;

    result.Add(remained);
}
result.Add(number);

result.Reverse();

foreach (int item in result)
{
    Console.Write(item.ToString());
}
