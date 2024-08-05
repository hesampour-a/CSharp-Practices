
using Common.Interfaces;

namespace GuessWordGame.Entities;

public class GuessWord(
    IUi ui,
    string description = "this is a guss word game between 5 words i defiend") : Game
{
    private string[] words { get; set; } = { "apple","hello","dotnet" , "pc" , "car" };
    private int randomIndex { get; set; } = new Random().Next(0, 4);
    private bool IsWin { get; set; } = false;
    public override string Name { get; init; } = "GuessWord";
    public override string Description { get ; init; } = description;

    void Start()
    {
        ui.Print("Enter a word :");
        if (ui.GetString() == words[randomIndex])
        {
            IsWin = true;
            ui.Print("wou win");
        }
        else
        {
            ui.Print("worng!");
        }
    }

    public override void Play()
    {
        while (!IsWin) { 
            Start();
        }
    }
}
