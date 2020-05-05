using System.Collections.Generic;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameTest
    {
        [Fact]
        public void GameShouldEndWhenUserRespondsQuit()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader("q");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, rng);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }

        [Fact]
        public void GameShouldStartARoundByRolling5Dice()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string> {"r", "q"});
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, rng);
            yatzy.PlayRound();
            Assert.NotEqual(0, yatzy.DiceCup[0].Value);
        }

        [Theory]
        [InlineData("a", 1)]
        [InlineData("A", 1)]
        [InlineData("c", 0)]
        [InlineData("D", 4)]
        [InlineData("O", 0)]
        [InlineData("e", 0)]
        [InlineData("F", 0)]
        [InlineData("G", 4)]
        [InlineData("h", 8)]
        [InlineData("l", 0)]
        [InlineData("k", 0)]
        public void GameShouldScoreIfResponseIsScoreInCategory(string input, int expected)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            var score = ScoreCalculator.CalculateScore(new List<int>
            {
                1,
                2,
                2,
                2,
                4
            }, player.Respond().Input.ToLower());
            Assert.Equal(expected, score);
        }

        [Fact]
        public void GameShouldNotScoreIfUsed()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string> {"a", "a", "q"});
            var player = new Player(consoleReader);
            var response = player.Respond();
            var scorecard = new ScoreCard();
            var round = new Round();
            var yatzy = new YatzyGame(player, scorecard, rng);
            yatzy.PlayRound();
            Assert.Equal(ResponseType.ScoreInCategory, response.ResponseType);
            yatzy.HandleResponse(response, round);
            Assert.Equal(ResponseType.InvalidResponse, response.ResponseType);
        }

        [Fact]
        public void CategoryShouldBeUsedIfScoredInCategory()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader("a");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, rng);
            Assert.False(scoreCard.CategoryScoreCard[0].IsUsed);
            yatzy.PlayRound();
            Assert.True(scoreCard.CategoryScoreCard[0].IsUsed);
        }

        [Fact]
        public void GameShouldThrowRoundOverExceptionWhenRollsExceeded()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string> {"r", "r", "r", "q"});
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, rng);
            Assert.Throws<RoundOverException>(() => yatzy.PlayGame());
        }

        [Fact]
        public void GameShouldEndWhenAllCategoriesScored()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
                "m",
                "n",
                "o"
            });
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, rng);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }
    }
}