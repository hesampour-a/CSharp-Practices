namespace Mountaineering.Entities;

public class MountaineeringGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Ascent(List<Ascent> ascents, int mountainId, DateTime date)
    {

        int newItemId = ascents.Count > 0 ? ascents.Last().Id + 1 : 1;
        ascents.Add(new Ascent
        {
            Id = newItemId,
            MountaineeringId = Id,
            MountainId = mountainId,
            Date = date,

        });
    }

    public void PrintMountaineeringGroup()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }

    public void PrintAscents(List<Ascent> ascents)
    {
        foreach (var ascent in ascents)
        {
            ascent.PrintAscent();
        }
    }
}