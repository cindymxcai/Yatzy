using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

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

        [Fact]
        public void DiceSum()
        {
            var calc = new ScoreCalculator();
            var dice = new Dice();
            int rollFirstDice = dice.RollDice();
            int rollSecondDice = dice.RollDice();
            List<int> dices = new List<int>();
            dices.Add(rollFirstDice);
            Assert.Equal(calc.getSumOfDice(rollFirstDice, dices), rollFirstDice );
            
        }
        
    }
}