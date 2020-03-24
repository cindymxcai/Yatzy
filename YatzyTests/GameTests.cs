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
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, new Response(Category.Ones)));
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
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, new Response(Category.Ones)));
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[] {true, false, false, false, false});
            game.RollDice();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        [Fact]
        public void HoldMethodShouldNotChangeHeldDiceValue()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, new Response(true)));
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[]{true, false, false, false, false});
            game.PlayUntilNoRollsLeft();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        [Fact]
        internal void RollThreeTimes()
        {
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(false, new Response(Category.Chance)));
            game.Hold(new[]{false, false, false, false, false});
            Assert.Equal(3, game.RollsLeft);
            game.RollDice();
            Assert.Equal(2, game.RollsLeft);

        }

        [Fact]
        internal void GameTest()
        {
            var reader = new TestConsoleReader(new List<string>(){"a,b", "R", "r", "r"});
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader));
            game.PlayUntilNoRollsLeft();
            Assert.Equal(0 ,game.RollsLeft);
        }
    }

    public class TestUserInput : IUserInput
    {
        private readonly bool _value;
       private readonly Response _response;

       public TestUserInput(bool value, Response response)
        {
            _value = value;
            _response = response;
        }
        
        public Response GetResponse()
        {
            return _response;
        }

        public bool IsReroll(string input)
        {
            return _value;
        }
        

        public Response GetHoldResponse(string input)
        {
            return _response;
        }

        public Response GetCategoryResponse(string input)
        {
            return _response;
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