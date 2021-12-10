using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeExamination.Model.Tests
{
    [TestClass()]
    public class CleanCodeExaminationTest
    {
        IBullsAndCows guessGame;

        [TestInitialize]
        public void Init()
        {
            guessGame = new BullsAndCows();
        }

        [TestMethod()]
        public void CreateGoalTest() 
        {
            int goalLength = guessGame.CreateGoal().Length;
            Assert.AreEqual(4, goalLength);
        }

        [TestMethod()]
        public void CheckBCTest()
        {
            string guess = "1234";
            string goal = "1234";
            string result = guessGame.CheckBC(goal,guess);
            string bulls = "BBBB";
            Assert.AreEqual(bulls, result.Substring(0,4));
        }

        [TestMethod()]
        public void CheckBCNoMatchTest()
        {
            string guess = "1234";
            string goal = "5678";
            string result = guessGame.CheckBC(goal, guess);
            string bull = ",";
            Assert.AreEqual(bull, result);
        }

        [TestMethod()]
        public void CheckCowsTest()
        {
            string guess = "1234";
            string goal = "4321";
            string result = guessGame.CheckBC(goal, guess);
            string cows = "CCCC";
            Assert.AreEqual(cows, result.Substring(1,4));
        }
    }
}