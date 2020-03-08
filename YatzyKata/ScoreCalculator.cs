using System.Collections.Generic;

namespace DiceTests
{
    public class ScoreCalculator
    {

        public int DiceSum = 0;
        public int getSumOfDice(int diceValue, List<int> dices)
        {
            foreach (var die in dices)
            {
                DiceSum += diceValue;
            }
            return DiceSum;
        }
        
        
    }
}