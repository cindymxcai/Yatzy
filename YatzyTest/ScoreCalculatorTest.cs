using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class ScoreCalculatorTest
    {
        private List<int> SetUpDice(int a, int b, int c, int d, int e)
        {
            var diceCup = new List<int> {a, b, c, d, e};
            return diceCup;
        }
        
        [Theory]
        [InlineData(5,5,5,5,5, 25)]
        [InlineData(1,6,5,2,5, 19)]

        public void DiceSumAndChanceTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expectedSum)
        {
            var scoreCalculator = new ScoreCalculator();
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expectedSum, scoreCalculator.GetSumOfDice(dice));
        }

        [Theory]
        [InlineData( 1, 1, 1, 1, 1, 50)]
        [InlineData(6, 6, 6, 6, 6, 50)]
        [InlineData( 3, 1, 1, 1, 1, 0)]
        public void YatzyTest  (int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var scoreCalculator = new ScoreCalculator();
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, scoreCalculator.Yatzy(dice));
        }

        [Theory]
        [InlineData(1, 1, 1, 2, 3, 3, 1)]
        [InlineData(3, 3, 3, 4, 5, 0, 1)]
        [InlineData(1, 2, 6, 2, 3, 4, 2)]
        [InlineData(2, 3, 2, 5, 1, 4, 2)]
        [InlineData(1, 1, 1, 2, 3, 3, 3)]
        [InlineData(1, 3, 3, 3, 5, 9, 3)]
        [InlineData(1, 4, 4, 2, 3, 8, 4)]
        [InlineData(1, 3, 1, 4, 5, 4, 4)]
        [InlineData(1, 1, 1, 2, 3, 0, 5)]
        [InlineData(5, 5, 1, 4, 5, 15, 5)]
        [InlineData(6, 6, 6, 6, 6, 30, 6)]
        [InlineData(1, 3, 1, 4, 6, 6, 6)]
        public void NumberScoresTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected, int categoryNumber)
        {
            var scoreCalculator = new ScoreCalculator();
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, scoreCalculator.NumberScore(dice, categoryNumber));
        }
        
        
    

    }
}