
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
            var diceCup = new List<Die> { new Die(), new Die(), new Die(), new Die(), new Die()};
            var round = new Round();
            round.RollDice(diceCup, new Rng());
            
            foreach (var die in diceCup)
            {
                Assert.NotEqual(0, die.Value);
            }
        }

        [Fact]
        public void RoundShouldThrowExceptionWhenRollingMoreThan3Times()
        {
            var diceCup = new List<Die> { new Die(), new Die(), new Die(), new Die(), new Die()};
            var round = new Round();
            round.RollDice(diceCup, new TestRng(1));
            round.RollDice(diceCup, new TestRng(1));
            round.RollDice(diceCup, new TestRng(1));

            Assert.Throws<RoundOverException>(() => round.RollDice(diceCup, new TestRng(1)) );
        }

        [Fact]
        public void HeldDiceShouldNotGetRolled()
        {
            var consoleReader = new TestConsoleReader("3,3,3");
            var player = new Player(consoleReader);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard);
            var round = new Round();
            round.HoldDice("3,3,3", yatzy.DiceCup);
            var rng = new TestRng(3);
            yatzy.PlayRound(rng);
            Assert.Equal(3, yatzy.DiceCup.Count(die => die.IsHeld));
            var newRng = new TestRng(1);
            round.RollDice(yatzy.DiceCup, newRng);
            Assert.Equal(2, yatzy.DiceCup.Count(die => die.Value == 1));
            Assert.Equal(3, yatzy.DiceCup.Count(die => die.Value == 3));
        }
    }
}