
using Common.Interfaces;

namespace GuessWordGame.Entities;

public class GuessWord(IUi ui) : Game
{
    private string[] words { get; set; } = { "apple","hello","dotnet" , "pc" , "car" };
    private int randomIndex { get; set; } = new Random().Next(0, 4);
    private bool IsWin { get; set; } = false;
    public override string Name { get; set; } = "GuessWord";

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
