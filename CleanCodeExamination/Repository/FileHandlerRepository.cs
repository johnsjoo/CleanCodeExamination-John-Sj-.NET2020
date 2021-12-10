using System;
using System.Collections.Generic;
using System.IO;

namespace CleanCodeExamination.DAL
{
    public class FileHandlerRepository : IFileHandlerRepository
    {

		public List<PlayerData> ReadPlayerData(string gametype)
		{
			StreamReader reader = new($"{gametype}Result.txt");
			List<PlayerData> scoreBoard = new();
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData PlayerData = new(name, guesses);
				int position = scoreBoard.IndexOf(PlayerData);

				if (position < 0)
				{
					scoreBoard.Add(PlayerData);
				}
				else
				{
					scoreBoard[position].Update(guesses);
				}
			}
			reader.Close();
			scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			return scoreBoard;
		}

		public void SavePlayerData(string name, int guesses,string gametype)
        {
            StreamWriter streamWriter = new($"{gametype}Result.txt", append: true);
            streamWriter.WriteLine(name + "#&#" + guesses);
			streamWriter.Close();
		} 
    }
}
