
using System.Collections.Generic;
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
            round.RollDice(diceCup);
            
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
            round.RollDice(diceCup);
            round.RollDice(diceCup);
            round.RollDice(diceCup);

            Assert.Throws<RoundOverException>(() => round.RollDice(diceCup) );
        }
    }
}