namespace Common.Interfaces;

public abstract class Game
{
    public abstract string Name { get; set; }

    public abstract void Play();
}
