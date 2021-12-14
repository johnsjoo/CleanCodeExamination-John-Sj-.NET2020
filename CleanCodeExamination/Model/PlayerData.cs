using System;

namespace CleanCodeExamination
{
	public class PlayerData
	{
		public string Name { get; private set; }
		public int TotGames { get; private set; }
		int TotalGuesses;

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			TotGames = 1;
			TotalGuesses = guesses;
		}

		public void Update(int guesses)
		{
			TotalGuesses += guesses;
			TotGames++;
		}

		public double Average()
		{
			return (double)TotalGuesses / TotGames;
		}

		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
