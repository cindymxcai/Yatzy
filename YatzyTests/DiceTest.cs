using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using YatzyKata;

namespace DiceTests
{
    public class DieTests
    {
        [Fact]
        public void DieRollShouldChangeValue()
        {
            var rng = new Rng();
            var dice = new Die(rng);
            int firstRoll = dice.RollDie();
            int secondRoll = dice.RollDie();
            Assert.NotSame((object)firstRoll, (object)secondRoll);
        }

        [Fact]
        public void DieShouldNotRollIfHeld()
        {
            //var rng = new Rng();
            var rng = new TestRng(6);
            var dice = new Die(rng);
            int rollDice = dice.RollDie();
            dice.IsHolding = true;
            int heldDice = dice.RollDie();
            Assert.Equal((object)rollDice, (object)heldDice);
        }

        
        public class TestRng : IRng
        {
            private readonly int _numberToReturn;

            public TestRng(int numberToReturn)
            {
                _numberToReturn = numberToReturn;
            }
            public int Next(int minValue, int maxValue)
            {
                return _numberToReturn;
            }
        }
    }
}