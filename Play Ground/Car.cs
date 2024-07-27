namespace Play_Ground;

public class Car(string name)
{
    public string Name { get; set; } = name;
    public bool HandBreakEngaged { get; set; } = true;

    public string Drive() => HandBreakEngaged ? "Hand Brake Is Engaged! Can't Move!!!" : $"Drive {Name}";

    public string Brake() => HandBreakEngaged ? "Hand Brake Is Alredy Engaged!" : $"Stop {Name}";

}