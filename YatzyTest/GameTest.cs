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
            var rng = new TestRng(1);
            yatzy.PlayGame(rng);
            Assert.False(yatzy.IsPlayingGame);
        }
        
        [Fact]
        public void GameShouldStartARoundByRolling5Dice()
        {
            var consoleReader = new TestConsoleReader(new List<string>{"r", "q"});
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            var rng = new TestRng(1);

            yatzy.PlayRound(rng);
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

        //TODO: IS THIS TEST VALID? PASS IN LIST OF STRINGS
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
            var rng = new TestRng(1);

            yatzy.PlayRound(rng);
            Assert.True( scoreCard.CategoryScoreCard[0].IsUsed);
        }

        [Fact]
        public void GameShouldThrowRoundOverExceptionWhenRollsExceeded()
        {
            var consoleReader = new TestConsoleReader(new List<string>{"r", "r", "r"});
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            var rng = new TestRng(1);

            Assert.Throws<RoundOverException>(() => yatzy.PlayRound(rng));
        }

        
        //TODO: 
        [Fact]
        public void GameShouldEndWhenAllCategoriesScored()
        {
            var consoleReader = new TestConsoleReader(new List<string>{"a", "b", "c", "d","e", "f", "g", "h", "i", "j", "k", "l","m", "n", "o"});
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            
            var yatzy = new YatzyGame(player, scoreCard);
            
            var rng = new TestRng(1);
            yatzy.PlayGame(rng);
            Assert.False(yatzy.IsPlayingGame);

        }
    }
}