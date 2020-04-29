using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoreCalculator
    {
        public int GetSumOfDice(IEnumerable<int> diceCup)
        {
            return diceCup.Sum();
        }

        public int Yatzy(IEnumerable<int> diceCup)
        {
            var dice = diceCup.ToList();
            return dice.All(die => die == dice.First()) ? 50 : 0;
        }

        public int NumberScore(List<int> diceCup, int categoryNumber)
        {
            var sum = 0;
            foreach (var dieValue in diceCup)
            {
                if (dieValue == categoryNumber )
                {
                    sum += dieValue;
                }
            }

            return sum;
        }
    }
}