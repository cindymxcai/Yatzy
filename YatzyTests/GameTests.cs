using System.Collections.Generic;
using Xunit;
using YatzyKata;

namespace DiceTests
{
    public class GameTests
    {
        [Fact]
        public void RollDice()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true,Category.None));
            var actual = game.GetValues();
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, actual);
        }

        [Fact]
        public void UserInputReroll()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, Category.None));
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[] {true, false, false, false, false});
            game.RollDice();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        [Fact]
        public void UserInputNoReroll()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(false, Category.None));
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[] {true, false, false, false, false});
            game.PromptAction();
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());   
        }

        [Fact]
        public void HoldRoll()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, Category.None));
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[]{true, false, false, false, false});
            game.PromptAction();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        //[Fact]
        internal void RollThreeTimes()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, Category.None));
            game.Hold(new[]{false, false, false, false, false});
            Assert.Equal(3, game.RollsLeft);
            game.PromptAction();
            game.PromptAction();
            game.PromptAction();
            Assert.Equal(2, game.RollsLeft);
            
        }
    }

    public class TestUserInput : IUserInput
    {
        private readonly bool _value;
        private readonly Category _category;

        public TestUserInput(bool value, Category category)
        {
            _value = value;
            _category = category;
        }
        
        public bool GetRerollResponse()
        {
            return _value;
        }

        public void GetHoldResponse()
        {
        }

        public Category GetCategoryResponse()
        {
            return _category;
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