using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameTest
    {

        [Fact]
        public void GameShouldEndWhenUserRespondsQuit()
        {
            var consoleReader = new TestConsoleReader("q");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }
        
        [Fact]
        public void GameShouldStartARoundByRolling5Dice()
        {
            var consoleReader = new TestConsoleReader("1");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            yatzy.PlayRound();
            Assert.NotEqual(0, yatzy.DiceCup[0].Value);
        }
        
        
        [Theory]
        [InlineData("a", 1)]
        [InlineData("A", 1)]
        [InlineData("c", 0)]
        [InlineData("D", 4 )]
        [InlineData("O", 0)]
        [InlineData("e", 0)]
        [InlineData("F", 0)]
        [InlineData("G", 4)]
        [InlineData("h", 8)]
        [InlineData("l", 0)]
        [InlineData("k", 0)]

        //TODO: IS THIS TEST VALID?
        public void GameShouldScoreIfResponseIsScoreInCategory(string input, int expected)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            var score = ScoreCalculator.CalculateScore(new List<int>{1,2,2,2,4}, player.Respond().Input.ToLower());
            Assert.Equal(expected, score);
        }

        [Fact]
        public void CategoryShouldBeUsedIfScoredInCategory()
        {
            var consoleReader = new TestConsoleReader("a");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard(); 
            var yatzy = new YatzyGame(player, scoreCard);
            Assert.False(scoreCard.CategoryScoreCard[0].IsUsed); 
            
            yatzy.PlayRound();
            Assert.True( scoreCard.CategoryScoreCard[0].IsUsed);
        }

        [Fact]
        public void GameShouldThrowRoundOverExceptionWhenRollsExceeded()
        {
            var consoleReader = new TestConsoleReader("r");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            Assert.Throws<RoundOverException>(() => yatzy.PlayRound());
        }
    }
    


    public class TestConsoleReader : IConsoleReader
    {
        private readonly string _inputString;

        public TestConsoleReader(string inputString)
        {
            _inputString = inputString;
        }
        public string GetInput()
        {
            return _inputString;
        }
    }
}