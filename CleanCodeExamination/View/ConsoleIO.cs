using System;

namespace CleanCodeExamination.Views
{
    public class ConsoleIO : IUserInterface
    {
        public bool Exit(string answer,bool playOn)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
            return playOn;
        }

        public string Input()
        {
            return Console.ReadLine().Trim();
        }

        public void Output(string s)
        {
            Console.WriteLine(s);
        }

        public void Clear() 
        {
            Console.Clear();
        }
    }
}
