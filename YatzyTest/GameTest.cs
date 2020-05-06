using System.Collections.Generic;
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
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns("q");
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, mockRng.Object);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }

        [Fact]
        public void GameShouldStartARoundByRolling5Dice()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput()).Returns("r").Returns("q");
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, mockRng.Object);
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
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns(input);
            var player = new Player(mockInput.Object);
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
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput()).Returns("a").Returns("a").Returns("q");
            var player = new Player(mockInput.Object);
            var response = player.Respond();
            var scorecard = new ScoreCard();
            var round = new Round();
            var yatzy = new YatzyGame(player, scorecard, mockRng.Object);
            yatzy.PlayRound();
            Assert.Equal(ResponseType.ScoreInCategory, response.ResponseType);
            yatzy.HandleResponse(response, round);
            Assert.Equal(ResponseType.InvalidResponse, response.ResponseType);
        }

        [Fact]
        public void CategoryShouldBeUsedIfScoredInCategory()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);            
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns("a");
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, mockRng.Object);
            Assert.False(scoreCard.CategoryScoreCard[0].IsUsed);
            yatzy.PlayRound();
            Assert.True(scoreCard.CategoryScoreCard[0].IsUsed);
        }

        [Fact]
        public void GameShouldThrowRoundOverExceptionWhenRollsExceeded()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput()).Returns("r").Returns("r").Returns("r").Returns("q");
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, mockRng.Object);
            Assert.Throws<RoundOverException>(() => yatzy.PlayGame());
        }

        [Fact]
        public void GameShouldEndWhenAllCategoriesScored()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);            
            
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput()).Returns("a").Returns("b").Returns("c").Returns("d").Returns("e").Returns("f").Returns("g").Returns("h").Returns("i").Returns("j").Returns("k").Returns("l").Returns("m").Returns("n").Returns("o");
            
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard, mockRng.Object);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }
    }
}