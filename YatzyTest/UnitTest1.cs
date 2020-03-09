using System;

namespace YatzyTest
{
    public class 
    {
        
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
        public void FoursTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(1, 4, 3, 3, 4);
            
            Assert.Equal(8, calc.Fours(dice));
        }

        //[Fact]
        public void PairsTest()
        {
            var calc = new ScoreCalculator();
            var dice = SetUpDice(1, 1, 3, 4, 6);
            
            Assert.Equal(2, calc.Pairs(dice));
        }
    }
}