namespace CleanCodeExamination.Model
{
    public interface IBullsAndCows
    {
        string CreateGoal();
        string CheckBC(string goal, string guess);
    }
}
