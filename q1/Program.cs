﻿int[] numbers = new int[10];

for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"Enter Number #{i + 1}");
    numbers[i] = int.Parse(Console.ReadLine());
}



int[] sortedArray = new int[numbers.Length];
int max = numbers[0];
int maxIndex = 0;
for (int j = 0; j < sortedArray.Length; j++)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
            maxIndex = i;
        }
    }


    sortedArray[j] = max;
    numbers = RemoveIndexFromArray(numbers, maxIndex);
    if (numbers.Length >= 1)
    {
        max = numbers[0];
        maxIndex = 0;
    }
}

Console.WriteLine("Answer : ");
for (int i = 0; i < sortedArray.Length; i++)
{
    Console.WriteLine(sortedArray[i]);

}
Console.WriteLine($"max : {sortedArray[0]}");
Console.WriteLine($"min : {sortedArray[sortedArray.Length - 1]}");

int[] RemoveIndexFromArray(int[] source, int index)
{
    if (index > source.Length - 1)
    {
        return source;
    }
    int[] newArray = new int[source.Length - 1];
    int k = 0;
    for (int i = 0; i < source.Length; i++)
    {
        if (i != index)
        {
            newArray[k] = source[i];
            k++;
        }

    }
    return newArray;
}





