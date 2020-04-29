using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public static class ScoreCalculator
    {
        public static int GetSumOfDice(IEnumerable<int> diceCup)
        {
            return diceCup.Sum();
        }

        public static int Yatzy(IEnumerable<int> diceCup)
        {
            var dice = diceCup.ToList();
            return dice.All(die => die == dice.First()) ? 50 : 0;
        }

        public static int NumberScore(IEnumerable<int> diceCup, int categoryNumber)
        {
            return diceCup.Where(dieValue => dieValue == categoryNumber).Sum();
        }

        public static int Pairs(List<int> diceCup)
        {
            var orderedDiceCup = new List<int>(diceCup.OrderByDescending(dieValue => dieValue));
            for (var currentDie = 0; currentDie < diceCup.Count - 1; currentDie++)
            {
                if (orderedDiceCup[currentDie] == orderedDiceCup[currentDie + 1])
                {
                    return orderedDiceCup[currentDie] + orderedDiceCup[currentDie + 1];
                }
            }

            return 0;
        }

        public static int TwoPairs(List<int> diceCup)
        {
            var numberOfPairs = 0;
            var sumOfPairs = 0;
            
            var orderedDiceCup = new List<int>(diceCup.OrderBy(die => die));
            for (var currentDie = 0; currentDie < diceCup.Count - 1; currentDie++)
            {
                if (orderedDiceCup[currentDie] == orderedDiceCup[currentDie + 1])
                {
                    sumOfPairs += orderedDiceCup[currentDie] + orderedDiceCup[currentDie + 1];
                    numberOfPairs++;
                }

                if (numberOfPairs == 2)
                {
                    return sumOfPairs;
                }
            }
            
            return 0;
        }


        public static int ThreeOfAKind(List<int> diceCup)
        {
            foreach (var die in diceCup.Where(die => diceCup.Count(dieValue => dieValue == die) >= 3))
            {
                return die * 3;
            }

            return 0;
        }

        public static int FourOfAKind(List<int> diceCup)
        {
            foreach (var die in diceCup.Where(die => diceCup.Count(dieValue => dieValue == die) >= 4))
            {
                return die * 4;
            }

            return 0;
        }
        
        public static int SmallStraight(IEnumerable<int> diceCup)
        {
            var orderedDiceCup = diceCup.OrderBy(dieValue => dieValue);
            var smallStraightMatch = new List<int>{1, 2, 3, 4, 5};
            return orderedDiceCup.SequenceEqual(smallStraightMatch) ? 15 : 0;
        }

        public static int LargeStraight(IEnumerable<int> diceCup)
        {
            var orderedDiceCup = diceCup.OrderBy(dieValue => dieValue);
            var largeStraightMatch = new List<int>{2, 3, 4, 5, 6};
            return orderedDiceCup.SequenceEqual(largeStraightMatch) ? 20 : 0;
        }

        public static int FullHouse(List<int> diceCup)
        {
            var distinctValues = diceCup.Distinct();
            
            if (distinctValues.Count() != 2) return 0;
            var sumOfThreeOfAKind = ThreeOfAKind(diceCup);
            var sumOfStrictPair = StrictPair(diceCup);
            return sumOfThreeOfAKind + sumOfStrictPair;
        }

        private static int StrictPair(IEnumerable<int> diceCup)
        {
            var groups = diceCup.GroupBy(diceValues => diceValues);
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