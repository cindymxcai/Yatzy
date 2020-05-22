using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using YatzyGame;
using YatzyGame.InputOutput;
using YatzyGame.Strategies;

namespace DieTest
{
    public class GameTest
    {
        [Fact]
        public void HeldDiceShouldNotGetRerolled()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput())
                .Returns("1,1,1")  
                .Returns("q");
            var player = new Player(mockInput.Object);
            var scorecard = new ScoreCard();
            var yatzy = new Game(player, scorecard, mockRng.Object);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, mockRng.Object);
            yatzy.HandleResponse(player.Respond());
           Assert.Equal(3, yatzy.DiceCup.Count(die => die.IsHeld));
        }

        [Fact]
        public void InputForNonExistentDieReturnsInvalid()
        {
            
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput())
                .Returns("2")  
                .Returns("q");
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var player = new Player(mockInput.Object);
            var scorecard = new ScoreCard();
            var yatzy = new Game(player, scorecard, mockRng.Object);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, mockRng.Object);
            var response = player.Respond();
            Round.HoldDice(response, yatzy.DiceCup);
            Assert.Equal(ResponseType.InvalidResponse, response.ResponseType);
        }
        
        [Fact]
        public void GameShouldEndWhenUserRespondsQuit()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns("q");
            var player = new Player(mockInput.Object);
            var scoreCard = new ScoreCard();
            var yatzy = new Game(player, scoreCard, mockRng.Object);
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
            var yatzy = new Game(player, scoreCard, mockRng.Object);
            yatzy.PlayRound();
            Assert.NotEqual(0, yatzy.DiceCup[0].Value);
        }

        [Theory]
        [InlineData("a", 1, 1,2,2,3,4)]
        [InlineData("A", 4, 1,1,1,1,6)]
        [InlineData("b", 6, 1,2,2,2,5 )]
        [InlineData("c", 0, 2,4,1,5,6)]
        [InlineData("D", 4, 4,1,2,5,1)]
        [InlineData("e", 0, 6,1,2,2,2)]
        [InlineData("F", 30, 6,6,6,6,6)]
        [InlineData("G", 4, 2,2,1,1,5)]
        [InlineData("h", 6, 1,1,2,2,5)]
        [InlineData("i", 6 ,2,2,2,4,5)]
        [InlineData("j", 16, 1,4,4,4,4)]
        [InlineData("k", 15, 1,2,3,4,5)]
        [InlineData("k", 0, 1,5,3,4,5)]
        [InlineData("L", 20, 2,3,4,5,6)]
        [InlineData("l", 0, 1,2,3,4,5)]
        [InlineData("m", 13, 2,2,3,3,3)]
        [InlineData("n", 11, 1,2,2,2,4)]
        [InlineData("O", 0, 1,3,4,5,6)]
        [InlineData("O", 50, 1,1,1,1,1)]
        
        
        
        
        public void GameShouldScoreIfResponseIsScoreInCategory(string input, int expected, int a, int b, int c, int d, int e)
        {
            var scoreCard = new ScoreCard();

            var score = ScoreCalculatorStrategy.CreateCalculator(scoreCard.CategoryScoreCard.First(category => category.CategoryKey == input.ToLower()), new List<Die>
            {
                new Die{ Value =  a},
                new Die{ Value =  b},
                new Die{ Value =  c},
                new Die{ Value =  d},
                new Die{ Value =  e}
            }).Calculate();
            Assert.Equal(expected, score);
        }

        [Fact]
        public void YatzyCategoryTest()
        {
            var scoreCard = new ScoreCard();

            var score = ScoreCalculatorStrategy.CreateCalculator(scoreCard.CategoryScoreCard.First(category => category.CategoryKey == "o"), new List<Die>
            {
                new Die{ Value =  1},
                new Die{ Value =  1},
                new Die{ Value =  1},
                new Die{ Value =  1},
                new Die{ Value =  1}
            }).Calculate();
            Assert.Equal(50, score);
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
            var yatzy = new Game(player, scorecard, mockRng.Object);
            yatzy.PlayRound();
            Assert.Equal(ResponseType.ScoreInCategory, response.ResponseType);
            yatzy.HandleResponse(response);
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
            var yatzy = new Game(player, scoreCard, mockRng.Object);
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
            var yatzy = new Game(player, scoreCard, mockRng.Object);
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
            var yatzy = new Game(player, scoreCard, mockRng.Object);
            yatzy.PlayGame();
            Assert.False(yatzy.IsPlayingGame);
        }
        
    }
}