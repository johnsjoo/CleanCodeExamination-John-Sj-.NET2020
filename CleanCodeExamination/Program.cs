using CleanCodeExamination.Controller;
using CleanCodeExamination.Views;
using CleanCodeExamination.Model;
using CleanCodeExamination.Repository;
using CleanCodeExamination.Model.Games;

namespace MooGame
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			IUserInterface ui = new ConsoleIO();
			IFileHandlerRepository fh = new FileHandlerRepository();
			var bullsAndCows = new BullsAndCows();
			var higherOrLower = new HighOrLow();
			GuessGameController controller = new(ui,fh,bullsAndCows,higherOrLower);
			controller.Run();
		}
	}
}