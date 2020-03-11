using System.Collections.Generic;
using Xunit;
using YatzyKata;
using static DiceTests.Mock<DiceTests.Dice>;

namespace DiceTests
{
    public class GameTests
    {

        [Fact]
        public void rollDice()
        {
            var expected = new List<int>{1,2,3,4,5};

            var game = new Game();
            var dice1 = new Dice();
            var dice2 = new Dice();
            var dice3 = new Dice();
            var dice4 = new Dice();
            var dice5 = new Dice();
           
           Assert.Equal(expected, game.RollDice(dice1, dice2, dice3,dice4,dice5));
           // make mock values and compare?
        }
        

        [Fact]
        public void RollHeld()
        {
            // RollDice(), then hold 3, should not roll
        }

        [Fact]
        public void rollThreeTimes()
        {
            //should no longer have rolls;
        }
    }

    internal class Mock<T>
    {
    }
}