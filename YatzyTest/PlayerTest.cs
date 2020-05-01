using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class PlayerTest
    {
        [Theory]
        [InlineData("1",  ResponseType.HoldDice)]
        [InlineData("1,2,3", ResponseType.HoldDice)]
        [InlineData("a", ResponseType.ScoreInCategory)]
        [InlineData("g", ResponseType.ScoreInCategory)]
        [InlineData("r", ResponseType.RerollDice)]
        [InlineData("R", ResponseType.RerollDice)]
        [InlineData("q", ResponseType.QuitGame)]
        [InlineData("Q", ResponseType.QuitGame)]


        public void PlayerShouldReturnResponseTypeGivenPlayerInput(string input, ResponseType responseType)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            Assert.Equal(responseType, player.Respond().ResponseType);
        }

        [Theory]
        [InlineData("a,a")]
        [InlineData("z,1")]
        [InlineData("8")]
        [InlineData("y")]
        
        public void ThrowExceptionIfPlayerGivesInvalidInput(string input)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            Assert.Throws<InvalidResponseException>(() => player.Respond());
        }
        
    }
}