using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yatzy;

namespace YatzyTest
{
    public class RoundTest
    {
        [Fact]
        public void RoundShouldReturn5ValuesWhenRolled()
        {
            var diceCup = new List<Die>
            {
                new Die(),
                new Die(),
                new Die(),
                new Die(),
                new Die()
            };
            var round = new Round();
            var rng = new TestRng(1);
            round.RollDice(diceCup, rng);
            foreach (var die in diceCup)
            {
                Assert.NotEqual(0, die.Value);
            }
        }

        [Fact]
        public void RoundShouldThrowExceptionWhenRollingMoreThan3Times()
        {
            var diceCup = new List<Die>
            {
                new Die(),
                new Die(),
                new Die(),
                new Die(),
                new Die()
            };
            var rng = new TestRng(1);
            var round = new Round();
            round.RollDice(diceCup, rng);
            round.RollDice(diceCup, rng);
            round.RollDice(diceCup, rng);
            Assert.Throws<RoundOverException>(() => round.RollDice(diceCup, rng));
        }

        [Fact]
        public void HeldDiceShouldNotGetRerolled()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string> {"1,1,1", "q"});
            var player = new Player(consoleReader);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard, rng);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, rng);
            yatzy.HandleResponse(player.Respond(), round);
            Assert.Equal(3, yatzy.DiceCup.Count(die => die.IsHeld));
        }

        [Fact]
        public void InputForNonExistentDieReturnsInvalid()
        {
            var rng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string> {"2", "q"});
            var player = new Player(consoleReader);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard, rng);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, rng);
            var response = player.Respond();
            Round.HoldDice(response, yatzy.DiceCup);
            Assert.Equal(ResponseType.InvalidResponse, response.ResponseType);
        }
    }
}