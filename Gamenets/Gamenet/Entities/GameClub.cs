using Common.Interfaces;

namespace Gamenet.Entities;

public class GameClub(List<Game?> games, IUi ui, string playerName)
{
    public string PlayerName { get; set; } = playerName;
    private List<Game?> _games = games;

    public void ShowMenu()
    {
        if (_games.Count == 0)
        {
            ui.Print("No games available");
            return;
        }

        while (true)
        {
            ui.Print($"Dear {PlayerName} Choose an option:");
            ui.Print("1. Play games");
            ui.Print("2. See Description of games");
            ui.Print("3. Exit");

            int userChoice = ui.GetNumberFromUser();
            switch (userChoice)
            {
                case 1:
                    ShowGames();
                    try
                    {
                    GetUserChoice()!.Play();
                    }
                    catch (Exception e)
                    {
                        ui.Print("Game not found");
                    }
                    
                    break;
                case 2:
                    ShowGames();
                    try
                    {
                    ui.Print(GetUserChoice()!.Description);
                    }
                    catch (Exception e)
                    {
                        ui.Print("Game not found");
                    }
                    break;
                case 3:
                    return;
            }
            ui.Clear();
        }


    }
    void ShowGames()
    {
        for (int i = 0; i < _games.Count; i++)
        {
            ui.Print($"{i + 1}. {_games[i]!.Name}");
        }
    }
    Game GetUserChoice()
    {
        ui.Print("Enter game number: ");


        return _games[ui.GetNumberFromUser() - 1];
               
    }

    public void AddGame(params Game[] game)
    {
        _games.AddRange(game);
    }
}
