using System.Linq;
using Moq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class GameTest
    {
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

        [Fact]
        public void GameShouldKeepPlayingCurrentRoundIfResponseTypeIsReroll()
        {
            var consoleReader = new TestConsoleReader("r");
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard();
            var yatzy = new YatzyGame(player, scoreCard);
            Assert.Throws<RoundOverException>(() => yatzy.PlayRound());
        }
        
        /*[Theory]
        [InlineData("a")]
        [InlineData("A")]
        [InlineData("c")]
        [InlineData("D")]
        [InlineData("O")]
        [InlineData("e")]
        [InlineData("F")]
        [InlineData("G")]
        [InlineData("h")]
        [InlineData("l")]
        [InlineData("k")]*/

        //TODO:
        /*public void GameShouldScoreIfResponseIsScoreInCategory(string input)
        {
            var consoleReader = new TestConsoleReader(input);
            var player = new Player(consoleReader);
            var scoreCard = new ScoreCard(); 
            var yatzy = new YatzyGame(player, scoreCard);
            yatzy.PlayRound();
        }*/
        
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