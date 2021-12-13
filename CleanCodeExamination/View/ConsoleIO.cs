using System;

namespace CleanCodeExamination.Views
{
    public class ConsoleIO : IUserInterface
    {
        public bool Exit(string answer,bool running)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                running = false;
            }
            return running;
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
