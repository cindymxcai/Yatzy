using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace DiceTests
{
    public class DiceTests
    {
        [Fact]
        public void DiceRollShouldChangeValue()
        {
            var rng = new Rng();
            var dice = new Dice(rng);
            int firstRoll = dice.RollDice();
            int secondRoll = dice.RollDice();
            Assert.NotSame((object)firstRoll, (object)secondRoll);
        }

        [Fact]
        public void DiceShouldNotRollIfHeld()
        {
            //var rng = new Rng();
            var rng = new TestRng(6);
            var dice = new Dice(rng);
            int rollDice = dice.RollDice();
            dice.IsHolding = true;
            int heldDice = dice.RollDice();
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