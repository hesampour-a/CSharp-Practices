using Common.Interfaces;

namespace Gamenet.Entities;

public class GameClub(List<Game> games, IUi ui, string playerName)
{

    public void ShowMenu()
    {
        if (games.Count == 0)
        {
            ui.Print("No games available");
            return;
        }

        while (true)
        {
            ui.Print($"Dear {playerName} Choose an option:");
            ui.Print("1. Play games");
            ui.Print("2. See Description of games");
            ui.Print("3. Exit");

            int userChoice = ui.GetNumberFromUser();
            switch (userChoice)
            {
                case 1:
                    ShowGames();
                    GetUserChoice().Play();
                    break;
                case 2:
                    ShowGames();
                    ui.Print(GetUserChoice().Description);
                    break;
                case 3:
                    return;
            }
            ui.Clear();
        }


    }
    void ShowGames()
    {
        for (int i = 0; i < games.Count; i++)
        {
            ui.Print($"{i + 1}. {games[i]!.Name}");
        }
    }
    Game GetUserChoice()
    {

        int userChoice = 0;
        do
        {
            ui.Print("Choose a game: ");
            userChoice = ui.GetNumberFromUser();
        } while (!(userChoice > 0 && userChoice <= games.Count));

        return games[userChoice - 1];
    }

    public void AddGame(params Game[] game)
    {
        games.AddRange(game);
    }
}
