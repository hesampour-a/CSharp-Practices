using Gamenet.Entities;
using GuessWordGame.Entities;
using Common.Entities;
using Common.Interfaces;
using GussNumberGame.Entities;


var consoleUi = new ConsoleUi();
List<Game> games = new List<Game>();
Game guessNumber = new GuessNumber(consoleUi);
Game guessWord = new GuessWord(consoleUi);

consoleUi.Print("Enter your name: ");


var gameNet = new GameClub(games, consoleUi ,consoleUi.GetString());

gameNet.AddGame(guessNumber, guessWord);
gameNet.ShowMenu();