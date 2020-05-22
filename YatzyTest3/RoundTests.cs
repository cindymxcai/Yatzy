using System.Collections.Generic;
using Moq;
using Xunit;
using YatzyGame;

namespace DieTest
{
    public class RoundTests
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
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);            
            round.RollDice(diceCup, mockRng.Object);
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
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var round = new Round();
            round.RollDice(diceCup, mockRng.Object);
            round.RollDice(diceCup, mockRng.Object);
            round.RollDice(diceCup, mockRng.Object);
            Assert.Throws<RoundOverException>(() => round.RollDice(diceCup, mockRng.Object));
        }
        
    }
}