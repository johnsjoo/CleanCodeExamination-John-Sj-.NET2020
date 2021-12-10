using CleanCodeExamination.Controller;
using CleanCodeExamination.Views;
using CleanCodeExamination.Model;
using CleanCodeExamination.DAL;
using CleanCodeExamination.Model.Games;

namespace MooGame
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			IUserInterface ui = new ConsoleIO();
			IFileHandlerRepository fh = new FileHandlerRepository();
			IBullsAndCows bullsAndCows = new BullsAndCows();
			IHighOrLow highOrLow = new HighOrLow();
			GuessGameController controller = new(ui, fh, bullsAndCows, highOrLow);
			controller.Run();
		}
	}
}