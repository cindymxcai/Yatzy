using System.Collections.Generic;

namespace DiceTests
{
    public interface IScoreCalculator
    {
        int getSumOfDice(List<int> dices);
        int Yatzy(List<int> dices);
        int Ones(List<int> dices);
        int Twos(List<int> dice);
        int Threes(List<int> dice);
        int Fours(List<int> dices);
        int Fives(List<int> dice);
        int Sixes(List<int> dice);
        int Pairs(List<int> dice);
        int TwoPairs(List<int> dice);
        int ThreeOfAKind(List<int> dice);
        int FourOfAKind(List<int> dice);
        int SmallStraight(List<int> dice);
        int LargeStraight(List<int> dice);
    }
}