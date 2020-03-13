using System.Collections.Generic;

namespace DiceTests
{
    public interface IScoreCalculator
    {
        int getSumOfDice(List<int> dices);
        int Yatzy(List<int> dices);
        int Ones(IEnumerable<int> dices);
        int Twos(IEnumerable<int> dice);
        int Threes(IEnumerable<int> dice);
        int Fours(IEnumerable<int> dices);
        int Fives(IEnumerable<int> dice);
        int Sixes(IEnumerable<int> dice);
        int Pairs(List<int> dice);
        int TwoPairs(List<int> dice);
        int ThreeOfAKind(List<int> dice);
        int FourOfAKind(List<int> dice);
        int SmallStraight(List<int> dice);
        int LargeStraight(List<int> dice);
    }
}