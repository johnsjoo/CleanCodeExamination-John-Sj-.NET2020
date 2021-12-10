namespace CleanCodeExamination.Views
{
    public interface IUserInterface
    {
        string Input();
        void Output(string s);
        bool Exit(string answer, bool playOn);
        void Clear();
    }
}
