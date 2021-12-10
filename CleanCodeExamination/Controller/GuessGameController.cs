using CleanCodeExamination.DAL;
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
		private readonly IBullsAndCows _bullsAndCows;
        private readonly IHighOrLow _highOrLow;

        public GuessGameController(IUserInterface ui, IFileHandlerRepository fh, IBullsAndCows bullsAndCows, IHighOrLow highOrLow)
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
            bool running = true;
            do
            {
                PrintMenu();
                var key = Console.ReadKey(true).Key;
                UserName = GetUserName();
                switch (key)
                {
                    case ConsoleKey.D1:
                        GameType = _bullsAndCows.GetType().Name;
                        _ui.Output("Game: Bulls and cows!");
                        _ui.Clear();
                        BullAndCowGame();
                        break;
                    case ConsoleKey.D2:
                        GameType = _highOrLow.GetType().Name;
                        _ui.Output("Game: Higher or lower!");
                        _ui.Clear();
                        HighOrLowGame();
                        break;
                    default:
                        running = false;
                        _ui.Clear();
                        _ui.Output("Invalid input");
                        break;
                }
            } while (!running);
        }

        //Games
        private void BullAndCowGame()
        {
            bool running = true;
            do
            {
                string goal = _bullsAndCows.CreateGoal();
                _ui.Output("New game:\n");
                BCGuessHandler(goal);
                _fh.SavePlayerData(UserName, TotGuesses, GameType);
                PrintScoreBoard(_fh.ReadPlayerData(GameType));
                PrintResult();
            } while (ContinueOrExit(running));
        }
        private void HighOrLowGame()
        {   
            bool running = true;
            do
            {
                string secretNumber = _highOrLow.CreateSecretNumber();
                _ui.Output("New game:\n");
                GuessNumberHandler(secretNumber);
                _fh.SavePlayerData(UserName, TotGuesses, GameType);
                PrintScoreBoard(_fh.ReadPlayerData(GameType));
                PrintResult();
            } while (ContinueOrExit(running));
        }

        //HelpMethods
        private void PrintMenu()
        {
            _ui.Output("Press key [1] for Bulls and cows \nPress key [2] for Higher or lower ");
        }
        private string GetUserName()
        {
            _ui.Output("Enter your user name:\n");
            return _ui.Input();
        }
        private void GuessNumberHandler(string secretNumber) 
        {
            _ui.Output($"For practice, number is: {secretNumber}\n");
            string guess = _ui.Input();
            string guessResult = _highOrLow.CheckGuess(secretNumber,guess);
            _ui.Output(guessResult);

            TotGuesses = 1;
            while (guessResult != "ok")
            {
                TotGuesses++;
                guess = _ui.Input();
                guessResult = _highOrLow.CheckGuess(secretNumber, guess);
                _ui.Output(guessResult);
            }
        }
        private void BCGuessHandler(string goal)
        {
            _ui.Output($"For practice, number is: {goal}\n");
            string guess = _ui.Input();
            string guessResult = _bullsAndCows.CheckBC(goal, guess);
            _ui.Output(guessResult + "\n");

            TotGuesses = 1;
            while (guessResult != "BBBB,")
            {
                TotGuesses++;
                guess = _ui.Input();
                _ui.Output(guess + "\n");
                guessResult = _bullsAndCows.CheckBC(goal, guess);
                _ui.Output(guessResult + "\n");
            }
        }
        private void PrintScoreBoard(List<PlayerData> scoreBoard)
        {
            _ui.Output("Player   games average");
            foreach (PlayerData player in scoreBoard)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NGames, player.Average()));
            }
        }
        private void PrintResult()
        {
            _ui.Output($"Correct, it took {TotGuesses} guesses\nContinue? Press [Y/N]");
        }
        private bool ContinueOrExit(bool run)
        {
            return _ui.Exit(_ui.Input(), run);
        }
       
    }
}
