using System.Collections.Generic;
using System.Linq;
using DiceTests;

namespace YatzyKata
{
    public class Game
    {
        private readonly List<Die> diceCup;
        private List<bool> _currentlyHolding;
        public int RollsLeft = 3;

        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5)
        {
             diceCup = new List<Die>{dice1, dice2, dice3, dice4, dice5};
        }
        
        public IEnumerable<int> GetValues()
        {
            return diceCup.Select(die => die.Result);
        }

        public void RollDice()
        {
            var zippedList = diceCup.Zip(_currentlyHolding, (die, hold) => new
            {
                hold = hold,
                die = die
            });
                
            foreach (var item in zippedList)
            {
                if (item.hold == false)
                {
                    item.die.RollDie();
                }
            }

            RollsLeft--;
        }

        public void Hold(List<bool> bools)
        {
             _currentlyHolding = bools;
        }
    }
}