
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
            
            var die = new Die();
            var testRng = new TestRng(1);
            var consoleReader = new TestConsoleReader(new List<string>{"1,1,1","r","q"});
            var player = new Player(consoleReader);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard)
            {
                DiceCup = new List<Die>
                {
                    die,
                    die,
                    die,
                    die,
                    die
                }
            };
            testRng.ChangeReturnValue(2);
            yatzy.PlayGame(testRng);
            Assert.Equal(3, yatzy.DiceCup.Count(dice => dice.IsHeld));
        }
    }
}