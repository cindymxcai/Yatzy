using System.Collections.Generic;
using System.Linq;

namespace DiceTests
{
    public class ScoreCalculator
    {

        public int DiceSum = 0;
  


        public int getSumOfDice(List<int> dices)
        {
            foreach (var dice in  dices)
            {
                DiceSum += dice;
            }

            return DiceSum;
        }

        public int Yatzy(List<int> dices)
        {
            int yatzyStreak = 0;

            foreach (var dice in dices)
            {
                if (dices[dice] == dices[dice+1])
                {
                     yatzyStreak++;
                }

                if (yatzyStreak > 4)
                {
                    DiceSum = 50;
                }
            }

            return DiceSum;
        }

        public int Ones(List<int> dices) //find better way to do this!!
        {
            foreach (var dice in dices)
            {
                if (dice == 1)
                {
                    DiceSum+= dice;
                }
            }
            return DiceSum;
        }

        
        public int Twos(List<int> dices)
        {
            foreach (var dice in dices)
            {
                if (dice == 2)
                {
                    DiceSum+= dice;
                }
            }
            return DiceSum;
        }
        
        public int Threes(List<int> dices)
        {
            foreach (var dice in dices)
            {
                if (dice == 3)
                {
                    DiceSum+= dice;
                }
            }
            return DiceSum;
        }
        
        
        public int Fours(List<int> dices)
        {
            foreach (var dice in dices)
            {
                if (dice == 4)
                {
                    DiceSum+= dice;
                }
            }
            return DiceSum;
        }
        
        public int Fives(List<int> dices)
        {
            foreach (var dice in dices)
            {
                if (dice == 5)
                {
                    DiceSum+= dice;
                }
            }
            return DiceSum;
        }

        public int Sixes(List<int> dices)
        {
            foreach (var dice in dices)
            {
                if (dice == 6)
                {
                    DiceSum += dice;
                }
            }

            return DiceSum;
        }
        
        
    }
}