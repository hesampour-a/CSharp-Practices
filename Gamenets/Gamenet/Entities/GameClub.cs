using Common.Interfaces;

namespace Gamenet.Entities;

public class GameClub(List<Game> games, IUi ui)
{
    public void ShowMenu()
    {
        ui.Print("Enter one of the games :");
        foreach (var game in games)
        {
            ui.Print(game.Name);
        }
        var gameName = Console.ReadLine();
        var selectedGame = games.Where(g => g.Name == gameName).First();
        if (selectedGame != null)
        {
            selectedGame.Play();
        }
    }
}
