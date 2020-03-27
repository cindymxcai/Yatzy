using System.Collections.Generic;

namespace DiceTests
{
    public interface IScoreCalculator
    {
        int GetSumOfDice(IEnumerable<int> dices);
        int Yatzy(IEnumerable<int> dices);

        int NumberScores(IEnumerable<int> dices, int number);
        int Pairs(IEnumerable<int> dice);
        int TwoPairs(IEnumerable<int> dice);
        int ThreeOfAKind(IEnumerable<int> dice);
        int FourOfAKind(IEnumerable<int> dice);
        int SmallStraight(IEnumerable<int> dice);
        int LargeStraight(IEnumerable<int> dice);
    }
}