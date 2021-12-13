namespace CleanCodeExamination.Model.Games
{
    public interface IGuessGame
    {
        string CreateGoal();
        string CheckGuess(string goal, string guess);
    }
}
