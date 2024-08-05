namespace Common.Interfaces;

public abstract class Game
{
    public abstract string Name { get; init; }

    public abstract string Description { get; init; }

    public abstract void Play();
}
