using CleanCodeExamination.Model.Games;
using System;

namespace CleanCodeExamination.Model
{
    public class BullsAndCows : IGuessGame
	{
		public string CreateGoal()
		{
			Random randomGenerator = new();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int randomNum = randomGenerator.Next(10);
				string currentNum = randomNum.ToString();
				while (goal.Contains(currentNum))
				{
					randomNum = randomGenerator.Next(10);
					currentNum = randomNum.ToString();
				}
				goal += currentNum;
			}
			return goal;
		}

		public string CheckGuess(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}	
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
    }
}
