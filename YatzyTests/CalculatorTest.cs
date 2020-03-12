using System.Collections.Generic;
using Xunit;

namespace DiceTests

{
    public class CalculatorTest
    {
        private List<int> SetUpDice(int a, int b, int c, int d, int e)
        {
            List<int> dice = new List<int>();
            dice.Add(a);
            dice.Add(b);
            dice.Add(c);
            dice.Add(d);
            dice.Add(e);

            return dice;
        }
        
        [Fact]
        public void DiceSumAndChanceTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(5, 3, 6, 1, 1);
            Assert.Equal(16, calc.getSumOfDice(dice));
        }

        [Theory]
        [InlineData(50, 1,1,1,1,1)]
        [InlineData(50, 6,6,6,6,6)]
        [InlineData(0, 3,1,1,1,1)]
        public void YatzyTest(int expected, int a, int b, int c, int d, int e) 
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a, b, c, d, e);
            var actual = calc.Yatzy(dice);
            Assert.Equal(expected, actual);
        }
        
        
        [Fact]
        public void OnesTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(2, 4, 3, 3, 5);
            
            Assert.Equal(0, calc.Ones(dice));
        }
        
        [Fact]
        public void TwosTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(2, 4, 5, 3, 4);
            
            Assert.Equal(2, calc.Twos(dice));
        }
        
        [Fact]
        public void ThreesTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(2, 4, 5, 3, 4);
            
            Assert.Equal(3, calc.Threes(dice));
        }
        
        [Fact]
        public void FoursTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(1, 4, 3, 3, 4);
            
            Assert.Equal(8, calc.Fours(dice));
        }

        [Fact]
        public void FiveTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(5, 4, 5, 5, 4);
            
            Assert.Equal(15, calc.Fives(dice));
        }

        [Fact]
        public void SixesTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(6, 6, 6, 6, 4);
            
            Assert.Equal(24, calc.Sixes(dice));
        }

        [Fact]
        public void PairsTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(1, 1, 1, 4, 6);
            
            Assert.Equal(2, calc.Pairs(dice));
        }

        [Fact]
        public void TwoPairs()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(3, 1, 5, 3, 1);
            
            Assert.Equal(8, calc.TwoPairs(dice));
        }

        [Theory]
        [InlineData(9, 3, 3, 3, 5, 6)]
        [InlineData(12, 4, 5 ,1 ,4 ,4 )]
        [InlineData(0, 3, 3,4,5,6)]
        [InlineData(9, 3,3,3,3,1)]
        public void ThreeOfAKind(int expected, int a, int b, int c, int d, int e)
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a,b,c,d,e);
            
            Assert.Equal(expected, calc.ThreeOfAKind(dice) );
        }
        
        [Theory]
        [InlineData(12, 3, 3, 3, 3, 6)]
        [InlineData(0, 4, 5 ,1 ,4 ,4 )]
        [InlineData(8,2,2,2,2,2)]
        [InlineData(0,2,2,2,5,5)]
        public void FourOfAKind(int expected, int a, int b, int c, int d, int e)
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a,b,c,d,e);
            
            Assert.Equal(expected, calc.FourOfAKind(dice) );
        }

        [Theory]
        [InlineData(15, 2,3,4,5,1)]
        [InlineData(15, 1,2,3,4,5)]
        [InlineData(0, 1,3,5,4,6)]
        public void SmallStraight(int expected, int a, int b, int c, int d, int e)
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a,b,c,d,e);
            
            Assert.Equal(expected, calc.SmallStraight(dice));
        }
        
        [Theory]
        [InlineData(20, 2,3,4,5,6)]
        [InlineData(20, 5,2,4,3,6)]
        [InlineData(0, 1,3,5,4,6)]
        [InlineData(0, 2,2,2,3,4)]
        public void LargeStraight(int expected, int a, int b, int c, int d, int e)
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a,b,c,d,e);
            
            Assert.Equal(expected, calc.LargeStraight(dice));
        }

        [Theory]
        [InlineData(13,2, 2, 3, 3, 3 )]
        [InlineData(0, 2,2,3,3,4)]
        [InlineData(0,4,4,4,4,4)]
        public void FullHouse(int expected, int a, int b, int c, int d, int e)
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(a,b,c,d,e);
            
           Assert.Equal(expected, calc.FullHouse(dice));
        }
    }
}