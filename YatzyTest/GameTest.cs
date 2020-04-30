using System.Collections.Generic;
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
            var yatzy = new YatzyGame(player);
            yatzy.PlayRound();
            Assert.NotEqual(0, yatzy.DiceCup[0].Value);
        }

        [Fact]
        public void GameShouldKeepPlayingCurrentRoundIfResponseTypeIsReroll()
        {
            var consoleReader = new TestConsoleReader("r");
            var player = new Player(consoleReader);
            var yatzy = new YatzyGame(player);
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