using Moq;
using Xunit;
using YatzyGame;
using YatzyGame.InputOutput;

namespace DieTest
{
    public class PlayerTests
    {
        [Theory]
        [InlineData("1", ResponseType.HoldDice)]
        [InlineData("1,2,3", ResponseType.HoldDice)]
        [InlineData("a", ResponseType.ScoreInCategory)]
        [InlineData("g", ResponseType.ScoreInCategory)]
        [InlineData("r", ResponseType.RerollDice)]
        [InlineData("R", ResponseType.RerollDice)]
        [InlineData("q", ResponseType.QuitGame)]
        [InlineData("Q", ResponseType.QuitGame)]
        public void PlayerShouldReturnResponseTypeGivenPlayerInput(string input, ResponseType responseType)
        {
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns(input);            
            var player = new Player(mockInput.Object);
            Assert.Equal(responseType, player.Respond().ResponseType);
        }

        [Theory]
        [InlineData("a,a")]
        [InlineData("z,1")]
        [InlineData("y")]
        [InlineData("8")]
        [InlineData("2,a")]
        public void ReturnInvalidResponseIfPlayerGivesInvalidInput(string input)
        {
            var mockInput = new Mock<IConsoleReader>();
            mockInput.Setup(consoleReader => consoleReader.GetInput()).Returns(input);      
            var player = new Player(mockInput.Object);
            Assert.Equal(ResponseType.InvalidResponse, player.Respond().ResponseType);
        }

    }
}