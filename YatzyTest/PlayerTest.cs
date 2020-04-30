using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class PlayerTest
    {
        [Theory]
        [InlineData("1", Response.HoldDice)]
        [InlineData("1,2,3", Response.HoldDice)]
        [InlineData("a", Response.ScoreInCategory)]
        [InlineData("g", Response.ScoreInCategory)]
        [InlineData("r", Response.RerollDice)]
        [InlineData("R", Response.RerollDice)]
        [InlineData("q", Response.QuitGame)]
        [InlineData("Q", Response.QuitGame)]


        public void PlayerShouldReturnResponseTypeGivenPlayerInput(string input, Response responseType)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            Assert.Equal(responseType,player.GetResponse() );
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
            Assert.Throws<InvalidResponseException>(() => player.GetResponse());
        }
    }
}