using System.Collections.Generic;
using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class GameTests
    {
        
        [Fact]
        public void rollDice()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3,dice4, dice5);
            var actual = game.GetValues();
            Assert.Equal(new List<int>{6,6,6,6,6}, actual);
        }

        [Fact]
        public void rerollDice()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3,dice4, dice5);
            Assert.Equal(new List<int>{6,6,6,6,6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new List<bool>{false,false,false, false,false});
            game.RollDice();
            Assert.Equal(new List<int>{1,1,1,1,1}, game.GetValues());
        }

        [Fact]
        public void holdRoll()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3,dice4, dice5);
            Assert.Equal(new List<int>{6,6,6,6,6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new List<bool>{true,false,false, false,false});
            game.RollDice();
            Assert.Equal(new List<int>{6,1,1,1,1}, game.GetValues());
        }
        
        [Fact]
        public void rollThreeTimes()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3,dice4, dice5);
            game.Hold(new List<bool>{false,false,false, false,false});
            Assert.Equal(3, game.RollsLeft);
            game.RollDice();
            Assert.Equal(2, game.RollsLeft);
            Assert.Equal(2, game.RollsLeft);
            game.RollDice();
            Assert.Equal(1, game.RollsLeft);
            game.RollDice();
            Assert.Equal(0, game.RollsLeft);
        }
    }

    public class TestRng : IRng
    {
        private int _numberToReturn;

        public TestRng(int numberToReturn)
        {
            _numberToReturn = numberToReturn;
        }
        public int Next(int minValue, int maxValue)
        {
            return _numberToReturn;
        }

        public void ChangeReturnValue(int n)
        {
            _numberToReturn = n;
        }
    }
}