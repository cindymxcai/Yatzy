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
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expectedSum, ScoreCalculator.GetSumOfDice(dice));
        }

        [Theory]
        [InlineData( 1, 1, 1, 1, 1, 50)]
        [InlineData(6, 6, 6, 6, 6, 50)]
        [InlineData( 3, 1, 1, 1, 1, 0)]
        public void YatzyTest  (int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.Yatzy(dice));
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
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.NumberScore(dice, categoryNumber));
        }

        [Theory]
        [InlineData(1, 1, 1, 4, 6, 2)]
        [InlineData(1, 4, 1, 4, 4, 8)]
        [InlineData(1, 2, 3, 4, 5, 0)]
        public void PairsTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.Pairs(dice));
        }

        [Theory]
        [InlineData(1, 1, 3, 2, 3, 8)]
        [InlineData(1, 1, 3, 4, 2, 0)]
        public void TwoPairsTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.TwoPairs(dice));
        }

        [Theory]
        [InlineData(3, 3, 3, 3, 6, 9)]
        [InlineData(4, 5, 1, 4, 4, 12)]
        [InlineData(2, 2, 2, 2, 2, 6)]
        [InlineData(2, 2, 1, 5, 5, 0)]
        [InlineData(1, 4, 1, 4, 4, 12)]
        public void ThreeOfAKindTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.ThreeOfAKind(dice));
        }

        [Theory]
        [InlineData(3, 3, 3, 3, 6, 12)]
        [InlineData(4, 5, 1, 4, 4, 0)]
        [InlineData(2, 2, 2, 2, 2, 8)]
        [InlineData(2, 2, 2, 5, 5, 0)]
        public void FourOfAKindTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.FourOfAKind(dice));
        }

        [Theory]
        [InlineData(2, 3, 4, 5, 1, 15)]
        [InlineData(1, 2, 3, 4, 5, 15)]
        [InlineData(1, 3, 4, 5, 6, 0)]
        public void SmallStraightTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.SmallStraight(dice));
        }

        [Theory]
        [InlineData(2, 3, 4, 5, 6, 20)]
        [InlineData(5, 2, 4, 3, 6, 20)]
        [InlineData(1, 2, 3, 4, 5, 0)]
        [InlineData(1, 3, 4, 5, 6, 0)]
        public void LargeStraightTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.LargeStraight(dice));
        }

        [Theory]
        [InlineData(2, 2, 3, 3, 3, 13)]
        [InlineData(2, 2, 3, 3, 4, 0)]
        [InlineData(2, 2, 2, 3, 3, 12)]
        [InlineData(4, 4, 4, 4, 4, 0)]
        public void FullHouseTest(int dieA, int dieB, int dieC, int dieD, int dieE, int expected)
        {
            var dice = SetUpDice(dieA, dieB, dieC, dieD, dieE);
            Assert.Equal(expected, ScoreCalculator.FullHouse(dice));
        }

    }
}