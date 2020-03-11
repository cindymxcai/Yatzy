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
            var dice = new Dice();
            int firstRoll = dice.RollDice();
            int secondRoll = dice.RollDice();
            Assert.NotSame((object)firstRoll, (object)secondRoll);
        }

        [Fact]
        public void DiceShouldNotRollIfHeld()
        {
            var dice = new Dice();
            int rollDice = dice.RollDice();
            dice._isHolding = true;
            int heldDice = dice.RollDice();
            Assert.Equal((object)rollDice, (object)heldDice);
        }

    }
}