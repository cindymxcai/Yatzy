using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DiceTests
{
    public class ScoreCalculator
    {

        public int DiceSum = 0;
  


        public int getSumOfDice(List<int> dices)
        {
            foreach (var dice in  dices)
            {
                DiceSum += dice;
            }

            return DiceSum;
        }

        public int Yatzy(List<int> dices)
        {

            if (dices.All(die => die == dices.First()))
            {
                DiceSum = 50;
            }

            return DiceSum;
        }

        private int SumNumbers(List<int> dices, int Number)
        {
            foreach (var dice in dices)
            {
                if (dice == Number)
                {
                    DiceSum += dice;
                }
            }

            return DiceSum;
        }

        public int Ones(List<int> dices)
        {
            return SumNumbers(dices, 1);
        }

        public int Twos(List<int> dice)
        {
            return SumNumbers(dice, 2);
        }

        public int Threes(List<int> dice)
        {
            return SumNumbers(dice, 3);
        }
        public int Fours(List<int> dices)
        {
            return SumNumbers(dices, 4);
        }
        
        public int Fives(List<int> dice)
        {
            return SumNumbers(dice, 5);
        }
        public int Sixes(List<int> dice)
        {
            return SumNumbers(dice, 6);
        }

        public int Pairs(List<int> dice)
        {
            List<int> ordered = new List<int>(dice.OrderByDescending(die => die));
            

            for (int i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i] == ordered[i + 1])
                {
                    return ordered[i] + ordered[i + 1];
                }
            }
            return 0;
        }
    }
}