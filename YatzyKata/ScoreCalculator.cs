using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using YatzyKata;

namespace DiceTests
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int DiceSum;
        public int getSumOfDice(List<int> dices)
        {
            DiceSum = 0;

            foreach (var dice in dices)
            {
                DiceSum += dice;
            }
            return DiceSum;
        }

        
        public int Yatzy(List<int> dices)
        {
            DiceSum = 0;

            if (dices.All(die => die == dices.First()))
            {
                DiceSum = 50;
            }
            return DiceSum;
        }

        private int SumNumbers(IEnumerable<int> dices, int Number)
        {
            DiceSum = 0;
            foreach (var dice in dices)
            {
                if (dice == Number)
                {
                    DiceSum += dice;
                }
            }
            return DiceSum;
        }

        public int Ones(IEnumerable<int> dices)
        {
            return SumNumbers(dices, 1);
        }

        public int Twos(IEnumerable<int> dice)
        {
            return SumNumbers(dice, 2);
        }

        public int Threes(IEnumerable<int> dice)
        {
            return SumNumbers(dice, 3);
        }

        public int Fours(IEnumerable<int> dices)
        {
            return SumNumbers(dices, 4);
        }

        public int Fives(IEnumerable<int> dice)
        {
            return SumNumbers(dice, 5);
        }

        public int Sixes(IEnumerable<int> dice)
        {
            return SumNumbers(dice, 6);
        }

        public int Pairs(List<int> dice)
        {
            DiceSum = 0;

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
            DiceSum = 0;

            List<int> ordered = new List<int>(dice.OrderBy(die => die));

            int  i = 0;
            if (ordered[i] == ordered[i + 1])
            {
                if (ordered[i + 1] == ordered[i + 2])
                {
                    
                     return ordered[i] + ordered[i + 1] + ordered[i+2]; 
                    
                }
            }
            
            return DiceSum;
        }
        
        public int FourOfAKind(List<int> dice)
        {
            DiceSum = 0;

            List<int> ordered = new List<int>(dice.OrderBy(die => die));

            int  i = 0;
            if (ordered[i] == ordered[i + 1])
            {
                if (ordered[i + 1] == ordered[i + 2])
                {
                    if (ordered[i + 2] == ordered[i + 3])
                    {
                        return ordered[i] + ordered[i + 1] + ordered[i+2] + ordered[i+3]; 
                    }
                }
            }
            
            return DiceSum;
        }

        public int SmallStraight(List<int> dice)
        {
            DiceSum = 0;

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
            DiceSum = 0;

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
            DiceSum = 0;

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