using System.Collections.Generic;

namespace CleanCodeExamination.Repository
{
    public interface IFileHandlerRepository
    {
        void SavePlayerData(string name, int guesses,string gametype);
        List<PlayerData> ReadPlayerData(string gametype);
    }
}