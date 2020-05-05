using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Round
    {
        public int RollsLeft { get; private set; } = 3;
        public void RollDice(IEnumerable<Die> diceCup, IRng rng)
        {
            var enumerableDiceCup = diceCup as Die[] ?? diceCup.ToArray();
            
            if (RollsLeft > 0)
            {
                foreach (var die in enumerableDiceCup)
                
                    if(die.IsHeld == false)
                    {
                        
                        die.Roll(rng);
                    }
                
                RollsLeft--;
            }
            else
            {
                throw new RoundOverException("You have run out of Rolls! Please choose a category");
            }
            foreach (var die in enumerableDiceCup)
            {
                die.IsHeld = false;
            }
        }

        public void HoldDice(string input, List<Die> diceCup)
        {
            var splitInput = input.Split(',');
            foreach (var holdValue in splitInput)
            {
                diceCup.First(die => !die.IsHeld && die.Value == int.Parse(holdValue)).IsHeld = true;
            }
        }
    }
}
