using Mountaineering.Entities;

var Mountains = new List<Mountain>();
var MountaineeringGroups = new List<MountaineeringGroup>();
var Ascents = new List<Ascent>();

run();

void run()
{
    bool exit = false;
    while (!exit)
    {

        Console.WriteLine("1. Add Mountain");
        Console.WriteLine("2. Add Mountaineering Group");
        Console.WriteLine("3. Add Ascent");
        Console.WriteLine("4. Print All Mountains");
        Console.WriteLine("5. Print All Mountaineering Groups");
        Console.WriteLine("6. Print All Ascents");
        Console.WriteLine("7. Report one");
        Console.WriteLine("8. Report tow");
        Console.WriteLine("9. Exit");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                GetNewMountainFromUser(Mountains);
                break;
            case 2:
                GetNewMountaineeringGroupFromUser(MountaineeringGroups);
                break;
            case 3:
                GetNewAscentFromUser(Ascents, Mountains, MountaineeringGroups);
                break;
            case 4:
                PrintAllMountains(Mountains);
                break;
            case 5:
                PrintAllMountaineeringGroups(MountaineeringGroups);
                break;
            case 6:
                PrintAllAscents(Ascents);
                break;
            case 7:
                PrintMostAscentedMountain(Ascents, Mountains);
                break;
            case 8:
                PrintCountOfAscentsOfEachMountaineeringGroupMoreThan4000(Ascents, MountaineeringGroups, Mountains);
                break;
            case 9:
                exit = true;
                break;
            default:
                break;
        }
        Console.WriteLine("Press  Enter to continue...");
        Console.ReadLine();
    }
}


void CreateNewMountain(List<Mountain> mountains, string name, int height)
{
    int newItemId = mountains.Count > 0 ? mountains.Last().Id + 1 : 1;
    mountains.Add(new Mountain
    {
        Id = newItemId,
        Name = name,
        Height = height

    });
}

void CreateNewMountaineeringGroup(List<MountaineeringGroup> mountaineeringGroups, string name)
{
    int newItemId = mountaineeringGroups.Count > 0 ? mountaineeringGroups.Last().Id + 1 : 1;
    mountaineeringGroups.Add(new MountaineeringGroup
    {
        Id = newItemId,
        Name = name
    });
}

void CreateNewAscent(List<Ascent> ascents, int mountainId, int mountaineeringGroupId, DateTime date)
{
    MountaineeringGroups[mountaineeringGroupId - 1].Ascent(ascents, mountainId, date);
}

void GetNewMountainFromUser(List<Mountain> mountains)
{
    Console.WriteLine("Enter Mountain Name: ");
    string name = Console.ReadLine()!;
    Console.WriteLine("Enter Mountain Height: ");
    int height = Convert.ToInt32(Console.ReadLine());
    CreateNewMountain(mountains, name, height);
}

void GetNewMountaineeringGroupFromUser(List<MountaineeringGroup> mountaineeringGroups)
{
    Console.WriteLine("Enter Mountaineering Group Name: ");
    string name = Console.ReadLine()!;
    CreateNewMountaineeringGroup(mountaineeringGroups, name);
}


void GetNewAscentFromUser(List<Ascent> ascents, List<Mountain> mountains, List<MountaineeringGroup> mountaineeringGroups)
{
    Console.WriteLine("Enter Mountain Id: ");
    int mountainId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Mountaineering Group Id: ");
    int mountaineeringGroupId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Date: ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    CreateNewAscent(ascents, mountainId, mountaineeringGroupId, date);
}

void PrintAllMountains(List<Mountain> mountains)
{
    foreach (var mountain in mountains)
    {
        mountain.PrintMountain();
    }
}

void PrintAllMountaineeringGroups(List<MountaineeringGroup> mountaineeringGroups)
{
    foreach (var mountaineeringGroup in mountaineeringGroups)
    {
        mountaineeringGroup.PrintMountaineeringGroup();
    }
}

void PrintAllAscents(List<Ascent> ascents)
{
    foreach (var ascent in ascents)
    {
        ascent.PrintAscent();
    }
}

void PrintMostAscentedMountain(List<Ascent> ascents, List<Mountain> mountains)
{
    Mountain mostAscentedMountain = mountains[0];
    int maxMountainAscentCount = 0;
    int currentMountainAscentCount = 0;
    foreach (var mountain in mountains)
    {
        foreach (var ascent in ascents)
        {
            if (ascent.MountainId == mountain.Id)
            {
                currentMountainAscentCount++;
            }
        }
        if (currentMountainAscentCount > maxMountainAscentCount)
        {
            mostAscentedMountain = mountain;
            maxMountainAscentCount = currentMountainAscentCount;
        }
        currentMountainAscentCount = 0;
    }
    Console.WriteLine($"The most ascented mountain is {mostAscentedMountain.Name} with {maxMountainAscentCount} ascents.");
}

void PrintCountOfAscentsOfEachMountaineeringGroupMoreThan4000(List<Ascent> ascents, List<MountaineeringGroup> mountaineeringGroups, List<Mountain> mountains)
{
    foreach (var mountaineeringGroup in mountaineeringGroups)
    {
        int count = 0;
        foreach (var ascent in ascents)
        {
            if (ascent.MountaineeringId == mountaineeringGroup.Id && mountains[ascent.MountainId - 1].Height > 4000)
            {
                count++;
            }
        }
        Console.WriteLine($"{mountaineeringGroup.Name} has {count} ascents of mountains with height greater than 4000 meters.");
    }
}




