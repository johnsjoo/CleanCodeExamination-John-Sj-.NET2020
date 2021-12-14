using CleanCodeExamination.Repository;
using CleanCodeExamination.Model;
using CleanCodeExamination.Model.Games;
using CleanCodeExamination.Views;
using System;
using System.Collections.Generic;

namespace CleanCodeExamination.Controller
{
    public class GuessGameController
    {
		private readonly IUserInterface _ui;
		private readonly IFileHandlerRepository _fh;
		private readonly BullsAndCows _bullsAndCows;
        private readonly HighOrLow _highOrLow;

        public GuessGameController(IUserInterface ui, IFileHandlerRepository fh, BullsAndCows bullsAndCows, HighOrLow highOrLow)
        {
			_ui = ui;
			_fh = fh;
			_bullsAndCows = bullsAndCows;
            _highOrLow = highOrLow;
		}

        private string GameType { get; set; }
        private string UserName { get; set; }
        private int TotGuesses { get; set; }

        public void Run()
        {
            bool run = true;
            UserName = GetUserName();
            _ui.Clear();
            do
            {
                PrintMenu();
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        _ui.Clear();
                        _ui.Output("Game: Bulls and cows!");
                        GameType = _bullsAndCows.GetType().Name;
                        Play(_bullsAndCows);
                        break;
                    case ConsoleKey.D2:
                        _ui.Clear();
                        GameType = _highOrLow.GetType().Name;
                        _ui.Output("Game: Higher or lower!");
                        Play(_highOrLow);
                        break;
                    default:
                        run = false;
                        _ui.Clear();
                        _ui.Output("Invalid input");
                        break;
                }
            } while (!run);
        }
        private void Play(IGuessGame guessGame)
        {
            bool run = true;
            do
            {
                string goal = guessGame.CreateGoal();
                _ui.Output("New game:\n");
                GuessHandler(goal, guessGame);
                _fh.SavePlayerData(UserName, TotGuesses, GameType);
                PrintScoreBoard(_fh.ReadPlayerData(GameType));
                PrintResult();
            } while (ContinueOrExit(run));
        }

        private void PrintMenu()
        {
            _ui.Output("Press key [1] for Bulls and cows \nPress key [2] for Higher or lower ");
        }
        private string GetUserName()
        {
            _ui.Output("Enter your user name:\n");
            return _ui.Input();
        }
        private void GuessHandler(string goal, IGuessGame guessGame)
        {
            _ui.Output($"For practice, number is: {goal}\n");
            string guess = _ui.Input();
            string guessResult = guessGame.CheckGuess(goal, guess);
            _ui.Output(guessResult + "\n");

            TotGuesses = 1;
            while (guess != goal)
            {
                TotGuesses++;
                guess = _ui.Input();
                guessResult = guessGame.CheckGuess(goal, guess);
                _ui.Output(guessResult + "\n");
            }
        }
        private void PrintScoreBoard(List<PlayerData> scoreBoard)
        {
            _ui.Output("Player   games average");
            foreach (PlayerData player in scoreBoard)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.TotGames, player.Average()));
            }
        }
        private void PrintResult()
        {
            _ui.Output($"Correct! It took {TotGuesses} guesses\nContinue? Press [Y/N]");
        }
        private bool ContinueOrExit(bool run)
        {
            return _ui.Exit(_ui.Input(), run);
        }
       
    }
}
