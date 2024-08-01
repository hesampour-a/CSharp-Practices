﻿using Gamenet.Entities;
using GuessNumberGame.Entities;
using GuessWordGame.Entities;
using Common.Entities;
using Common.Interfaces;


var consoleUi = new ConsoleUi();
List<Game> games = new List<Game>();
Game guessNumber = new GuessNumber(consoleUi);
Game guessWord = new GuessWord(consoleUi);
games.Add(guessNumber);
games.Add(guessWord);


var gameNet = new GameClub(games, consoleUi);
gameNet.ShowMenu();