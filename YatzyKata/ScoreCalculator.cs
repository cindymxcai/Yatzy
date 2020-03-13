using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DiceTests
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int DiceSum = 0;
        public int getSumOfDice(List<int> dices)
        {
            foreach (var dice in dices)
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
            List<int> ordered = new List<int>(dice.OrderBy(die => die));
            
            for (int i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i] == ordered[i + 1])
                {
                    return ordered[i] + ordered[i + 1];
                }
            }
            return 0;
        }

        public int TwoPairs(List<int> dice)
        {
            int numPairs = 0;
            int pairSum = 0;
            
            List<int> ordered = new List<int>(dice.OrderBy(die => die));

            for (int i = 0; i < dice.Count -1; i++)
            {
                if (ordered[i] == ordered[i + 1])
                {
                    pairSum += ordered[i] + ordered[i + 1];
                    numPairs++;
                }

                if (numPairs == 2)
                {
                    break;
                }
            }
            return pairSum;
        }

        public int ThreeOfAKind(List<int> dice)
        {
            List<int> ordered = new List<int>(dice.OrderBy(die => die));

            int  i = 0;
            if (ordered[i] == ordered[i + 1])
            {
                if (ordered[i + 1] == ordered[i + 2])
                {
                    
                        DiceSum =  ordered[i] + ordered[i + 1] + ordered[i+2]; 
                    
                }
            }
            
            return DiceSum;
        }
        
        public int FourOfAKind(List<int> dice)
        {
            List<int> ordered = new List<int>(dice.OrderBy(die => die));

            int  i = 0;
            if (ordered[i] == ordered[i + 1])
            {
                if (ordered[i + 1] == ordered[i + 2])
                {
                    if (ordered[i + 2] == ordered[i + 3])
                    {
                        DiceSum =  ordered[i] + ordered[i + 1] + ordered[i+2] + ordered[i+3]; 
                    }
                }
            }
            
            return DiceSum;
        }

        public int SmallStraight(List<int> dice)
        {
            List<int> ordered = new List<int>(dice.OrderBy(die => die));
            List<int> smallStraight = new List<int>{1,2,3,4,5};
            if (ordered.SequenceEqual(smallStraight))
            {
                return 15;
            }
            return DiceSum;
        }

        public int LargeStraight(List<int> dice)
        {
            var ordered = new List<int>(dice.OrderBy(die => die));
            var largeStraight = new List<int> {2, 3, 4, 5, 6};

            if (ordered.SequenceEqual(largeStraight))
            {
                return 20;
            }
            return DiceSum;        
        }

        public int FullHouse(List<int> dice)
        {
            var ordered = (IEnumerable<int>)dice.OrderBy(die=> die);
            var enumerable = ordered.ToList();
            if (enumerable.Select((number1,number2) => number1-number2).Distinct().Skip(1).Any())
            {
                return enumerable.Sum();
            }
            return DiceSum;
        }
    }
}