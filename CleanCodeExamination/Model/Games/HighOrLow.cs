using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExamination.Model.Games
{
    public class HighOrLow : IHighOrLow
    {
        public string CreateSecretNumber() 
        {
            Random randomGenerator = new();
            string secretNumber = randomGenerator.Next(100).ToString();
            return secretNumber;
        }

        public string CheckGuess(string secretNumber,string guess)
        {
            int guessToInt = ConvertToInt(guess);
            int secretNumbToInt = ConvertToInt(secretNumber);

            if (guessToInt < secretNumbToInt)
            {
                return "Higher";
            }
            if (guessToInt > secretNumbToInt)
            {
                return "Lower";
            }
            else
            {
                return "ok";
            }
        }

        public int ConvertToInt(string number) 
        {
            return Convert.ToInt32(number);
        }
    }
}
