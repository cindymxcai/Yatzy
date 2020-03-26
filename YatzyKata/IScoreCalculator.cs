using System.Collections.Generic;

namespace DiceTests
{
    public interface IScoreCalculator
    {
        int getSumOfDice(IEnumerable<int> dices);
        int Yatzy(IEnumerable<int> dices);

        int NumberScores(IEnumerable<int> dices, int number);
        /*int Ones(IEnumerable<int> dices);
        int Twos(IEnumerable<int> dice);
        int Threes(IEnumerable<int> dice);
        int Fours(IEnumerable<int> dices);
        int Fives(IEnumerable<int> dice);
        int Sixes(IEnumerable<int> dice);*/
        int Pairs(IEnumerable<int> dice);
        int TwoPairs(IEnumerable<int> dice);
        int ThreeOfAKind(IEnumerable<int> dice);
        int FourOfAKind(IEnumerable<int> dice);
        int SmallStraight(IEnumerable<int> dice);
        int LargeStraight(IEnumerable<int> dice);
    }
}