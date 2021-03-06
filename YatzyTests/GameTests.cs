using System.Collections.Generic;
using System.Linq;
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
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new TestUserInput(true, new Response(Category.Ones)), new bool[5]);
            var actual = game.GetValues();
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, actual);
        }

        [Fact]
        public void UserInputReroll()
        {
            var reader = new TestConsoleReader(new List<string>(){ "r","q"});
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[] {true, false, false, false, false});
            game.Play();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        [Fact]
        public void HoldMethodShouldNotChangeHeldDiceValue()
        {
            var reader = new TestConsoleReader(new List<string>(){ "a","q"});
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            Assert.Equal(new List<int> {6, 6, 6, 6, 6}, game.GetValues());
            rng.ChangeReturnValue(1);
            game.Hold(new[]{true, false, false, false, false});
            game.Play();
            Assert.Equal(new List<int> {6, 1, 1, 1, 1}, game.GetValues());
        }

        [Fact]
        public void GameShouldQuitWhenAllCategoriesScored()
        {
            var reader = new TestConsoleReader(new List<string>(){ "1","2","3","4","5","6","7","8","9","10","11","12","13","14","15"});
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            game.Play();
            Assert.False(game.PlayingGame);
        }
        
        [Fact]
        public void PlayGameTestRollsLeft()
        {
            var reader = new TestConsoleReader(new List<string>(){"a,b","q"});
            var rng = new TestRng(6);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader),  new bool[5]);
            game.Play();
            Assert.Equal(1 ,game.RollsLeft);
        }

        [Fact]
        public void PlayGameAndTestGameStoresScoreInCategory()
        {
            var reader = new TestConsoleReader(new List<string>(){"1", "R", "R", "R","q"});
            var rng = new TestRng(1);
            var dice1 = new Die(rng);
            var dice2 = new Die(rng);
            var dice3 = new Die(rng);
            var dice4 = new Die(rng);
            var dice5 = new Die(rng);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            game.Play();
            Assert.Equal(5, game.ScoreCard.Scores.Where(cat => cat.Category == Category.Ones).Select(cat => cat.Score).First());
        }

        [Fact]
        public void PlayGameTestScoreCardTotal()
        {
            var reader = new TestConsoleReader(new List<string>(){"1", "r", "5", "R","Q"});
            var rng1 = new TestRng(1);
            var rng5 = new TestRng(5);
            var dice1 = new Die(rng1);
            var dice2 = new Die(rng1);
            var dice3 = new Die(rng5);
            var dice4 = new Die(rng5);
            var dice5 = new Die(rng5);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            game.Play();
            Assert.Equal(17, game.ScoreCard.Total);
        }
        
        [Fact]
        public void PlayGameTestQuit()
        {
            var reader = new TestConsoleReader(new List<string>(){"r","Q"});
            var rng1 = new TestRng(1);
            var rng5 = new TestRng(5);
            var dice1 = new Die(rng1);
            var dice2 = new Die(rng1);
            var dice3 = new Die(rng5);
            var dice4 = new Die(rng5);
            var dice5 = new Die(rng5);
            var game = new Game(dice1, dice2, dice3, dice4, dice5, new UserInput(reader), new bool[5]);
            game.Play();
            Assert.Equal(0, game.ScoreCard.Total);
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
}