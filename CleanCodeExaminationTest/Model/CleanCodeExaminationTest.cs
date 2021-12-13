using CleanCodeExamination.Model.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeExamination.Model.Tests
{
    [TestClass()]
    public class CleanCodeExaminationTest
    {
    
        BullsAndCows bullsAndCows;

        [TestInitialize]
        public void Init()
        {
            bullsAndCows = new();
        }

        [TestMethod()]
        public void CreateGoalTest() 
        {
            int goalLength = bullsAndCows.CreateGoal().Length;
            int expected = 4;
            Assert.AreEqual(expected, goalLength);
        }

        [TestMethod()]
        public void CheckGuessOnlyBullsTest()
        {
            string guess = "1234";
            string goal = "1234";
            string expected = "BBBB";
            string result = bullsAndCows.CheckGuess(goal, guess);
            Assert.AreEqual(expected, result.Substring(0,4));
        }

        [TestMethod()]
        public void CheckGuessNoMatchTest()
        {
            string guess = "1234";
            string goal = "5678";
            string expected = ",";
            string result = bullsAndCows.CheckGuess(goal, guess);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckGuessOnlyCowsTest()
        {
            string guess = "1234";
            string goal = "4321";
            string expected = "CCCC";
            string result = bullsAndCows.CheckGuess(goal, guess);
            Assert.AreEqual(expected, result.Substring(1,4));
        }
    }
}