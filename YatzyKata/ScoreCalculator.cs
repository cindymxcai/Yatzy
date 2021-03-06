using System;
using System.Collections.Generic;
using System.Linq;
using DiceTests;

namespace YatzyKata
{
    public class ScoreCalculator : IScoreCalculator
    {
        private int _diceSum;

        public int GetScore(Category category, IEnumerable<int> dice)
        {
            
            var score = category switch
            {
                Category.Ones => NumberScores(dice, 1),
                Category.Twos => NumberScores(dice, 2),
                Category.Threes => NumberScores(dice, 3),
                Category.Fours => NumberScores(dice, 4),
                Category.Fives => NumberScores(dice, 5),
                Category.Sixes => NumberScores(dice, 6),
                Category.Pairs => Pairs(dice),
                Category.TwoPairs => TwoPairs(dice) ,
                Category.ThreeOfAKind => ThreeOfAKind(dice),
                Category.FourOfAKind => FourOfAKind(dice),
                Category.SmallStraight => SmallStraight(dice),
                Category.LargeStraight => LargeStraight(dice),
                Category.FullHouse => FullHouse(dice),
                Category.Chance => GetSumOfDice(dice),
                Category.Yatzy => Yatzy(dice),
               _ => throw new Exception($"Invalid Category in ScoreCalculator.GetScore {category}")
            };

            return score;
        }

        public int GetSumOfDice(IEnumerable<int> dices)
        {
            _diceSum = 0;

            foreach (var dice in dices)
            {
                _diceSum += dice;
            }

            return _diceSum;
        }


        public int Yatzy(IEnumerable<int> dices)
        {
            _diceSum = 0;

            var enumerable = dices.ToList();
            if (enumerable.All(die => die == enumerable.First()))
            {
                _diceSum = 50;
            }

            return _diceSum;
        }

        private int SumNumbers(IEnumerable<int> dices, int number)
        {
            _diceSum = 0;
            foreach (var dice in dices)
            {
                if (dice == number)
                {
                    _diceSum += dice;
                }
            }

            return _diceSum;
        }
        
        public int NumberScores(IEnumerable<int> dices, int number)
        {
            return SumNumbers(dices, number);
        }
        
        public int Pairs(IEnumerable<int> dice)
        {
            _diceSum = 0;

            var ordered = new List<int>(dice.OrderByDescending(die => die));

            for (var i = 0; i < ordered.Count - 1; i++)
            {
                if (ordered[i] == ordered[i + 1])
                {
                    return ordered[i] + ordered[i + 1];
                }
            }

            return _diceSum;
        }

        public int TwoPairs(IEnumerable<int> dice)
        {
            int numPairs = 0;
            int pairSum = 0;

            var enumerable = dice as int[] ?? dice.ToArray();
            List<int> ordered = new List<int>(enumerable.OrderBy(die => die));

            for (int i = 0; i < enumerable.Length - 1; i++)
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

        public int ThreeOfAKind(IEnumerable<int> dice)
        {
            var enumerable = dice as int[] ?? dice.ToArray();
            return (from die in enumerable where enumerable.Count(d => d == die) >= 3 select die * 3).FirstOrDefault();
        }

        public int FourOfAKind(IEnumerable<int> dice)
        {
            var enumerable = dice as int[] ?? dice.ToArray();
            foreach (var die in enumerable)
            {
                if (enumerable.Count(d => d == die) >= 4)
                {
                    return die * 4;
                }
            }
            return 0;
        }

        public int SmallStraight(IEnumerable<int> dice)
        {
            _diceSum = 0;

            List<int> ordered = new List<int>(dice.OrderBy(die => die));
            List<int> smallStraight = new List<int> {1, 2, 3, 4, 5};
            if (ordered.SequenceEqual(smallStraight))
            {
                return 15;
            }

            return _diceSum;
        }

        public int LargeStraight(IEnumerable<int> dice)
        {
            _diceSum = 0;

            var ordered = new List<int>(dice.OrderBy(die => die));
            var largeStraight = new List<int> {2, 3, 4, 5, 6};

            if (ordered.SequenceEqual(largeStraight))
            {
                return 20;
            }

            return _diceSum;
        }

        public int FullHouse(IEnumerable<int> dice)
        {
            var enumerable = dice as int[] ?? dice.ToArray();

            if (!HasTwoGroups(enumerable)) return 0;
            var sumOfThreeOfAKind = ThreeOfAKind(enumerable);
            var sumOfPerfectPairs = PerfectPairs(enumerable);
            return sumOfThreeOfAKind + sumOfPerfectPairs;
        }

        private static bool HasTwoGroups(IEnumerable<int> dice)
        {
            var enumerable = dice as int[] ?? dice.ToArray();
            var distinctValues = enumerable.Distinct().ToList();

            return distinctValues.Count == 2;
        }

        private static int PerfectPairs(IEnumerable<int> dice)
        {
            var enumerable = dice as int[] ?? dice.ToArray();
            var groups = enumerable.GroupBy(diceValues => diceValues);

            foreach (var group in groups)
            {
                if (group.Count() == 2)
                {
                    return group.Sum();
                }
            }

            return 0;
        }

        

    }
}