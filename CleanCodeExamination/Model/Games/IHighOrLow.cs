namespace CleanCodeExamination.Model.Games
{
    public interface IHighOrLow
    {
        string CreateSecretNumber();
        string CheckGuess(string secretNumber, string guess);
        int ConvertToInt(string number);
    }
}