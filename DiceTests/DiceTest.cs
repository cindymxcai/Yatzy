using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace DiceTests
{
    public class DiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

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
        public void DiceSumAndChanceTest()
        {
            var calc = new ScoreCalculator();
            int diceOne = 3;
            int diceTwo = 2;
            int diceThree = 4;
            List<int> dices = new List<int>();
            dices.Add(diceOne);
            dices.Add(diceTwo);
            dices.Add(diceThree);
           Assert.Equal(9, calc.getSumOfDice(dices));
        }

        [Fact]
        public void YatzyTest()  //breaks if last dice is 3 as should but doesnt if 2? anything greater is out of range?
        {
            var calc = new ScoreCalculator();
            int diceOne = 1;
            int diceTwo = 1;
            int diceThree = 1;
            int diceFour = 1;
            int diceFive = 2;
            List<int> dices = new List<int>();
            dices.Add(diceOne);
            dices.Add(diceTwo);
            dices.Add(diceThree);
            dices.Add(diceFour);
            dices.Add(diceFive);
            Assert.Equal(50, calc.Yatzy(dices));
        }
        
        [Fact]
        public void NonYatzyTest()
        {
            var calc = new ScoreCalculator();
            int diceOne = 1;
            int diceTwo = 1;
            int diceThree = 3;
            int diceFour = 3;
            int diceFive = 1;
            List<int> dices = new List<int>();
            dices.Add(diceOne);
            dices.Add(diceTwo);
            dices.Add(diceThree);
            dices.Add(diceFour);
            dices.Add(diceFive);
            Assert.Equal(0, calc.Yatzy(dices));
        }


        [Fact]
        public void OnesTest()
        {
            var calc = new ScoreCalculator();
            int diceOne = 2;
            int diceTwo = 4;
            int diceThree = 3;
            int diceFour = 3;
            int diceFive = 5;
            List<int> dices = new List<int>();
            dices.Add(diceOne);
            dices.Add(diceTwo);
            dices.Add(diceThree);
            dices.Add(diceFour);
            dices.Add(diceFive);
            
            Assert.Equal(0, calc.Ones(dices));
        }
        [Fact]
        public void FoursTest()
        {
            var calc = new ScoreCalculator();
            int diceOne = 1;
            int diceTwo = 4;
            int diceThree = 3;
            int diceFour = 3;
            int diceFive = 4;
            List<int> dices = new List<int>();
            dices.Add(diceOne);
            dices.Add(diceTwo);
            dices.Add(diceThree);
            dices.Add(diceFour);
            dices.Add(diceFive);
            
            Assert.Equal(8, calc.Fours(dices));
        }
        
        
        
        
    }
}