using System.Collections.Generic;

namespace CleanCodeExamination.Repository
{
    public interface IFileHandlerRepository
    {
        void SavePlayerData(string name, int nGuess,string gametype);
        List<PlayerData> ReadPlayerData(string gametype);
    }
}