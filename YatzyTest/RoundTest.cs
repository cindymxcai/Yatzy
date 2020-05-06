using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
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

        [Fact]
        public void HeldDiceShouldNotGetRerolled()
        {
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput())
                .Returns("1,1,1")  
                .Returns("q");
            var player = new Player(mockInput.Object);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard, mockRng.Object);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, mockRng.Object);
            yatzy.HandleResponse(player.Respond(), round);
            Assert.Equal(3, yatzy.DiceCup.Count(die => die.IsHeld));
        }

        [Fact]
        public void InputForNonExistentDieReturnsInvalid()
        {
            
            var mockInput = new Mock<IConsoleReader>();
            mockInput.SetupSequence(consoleReader => consoleReader.GetInput())
                .Returns("2")  
                .Returns("q");
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var player = new Player(mockInput.Object);
            var scorecard = new ScoreCard();
            var yatzy = new YatzyGame(player, scorecard, mockRng.Object);
            var round = new Round();
            round.RollDice(yatzy.DiceCup, mockRng.Object);
            var response = player.Respond();
            Round.HoldDice(response, yatzy.DiceCup);
            Assert.Equal(ResponseType.InvalidResponse, response.ResponseType);
        }
    }
}