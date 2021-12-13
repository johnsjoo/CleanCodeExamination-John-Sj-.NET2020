using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Model.Games
{
    public class HighOrLow : IGuessGame
    {
        public string CreateGoal() 
        {
            Random randomGenerator = new();
            return randomGenerator.Next(100).ToString();
        }

        public string CheckGuess(string goal,string guess)
        {
            int guessToInt = ConvertToInt(guess);
            int goalToInt = ConvertToInt(goal);

            if (guessToInt < goalToInt)
            {
                return "Higher";
            }
            if (guessToInt > goalToInt) 
            {
                return "Lower";
            }
            else
            {
                return "ok";
            }
        }

        private int ConvertToInt(string number)
        {
            return Convert.ToInt32(number);
        }
    }
}
