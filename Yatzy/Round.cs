using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Round
    {
        private int RollsLeft { get; set; } = 3;
        private readonly IRng _rng = new Rng();

        public void RollDice(IEnumerable<Die> diceCup)
        {
            var enumerableDiceCup = diceCup as Die[] ?? diceCup.ToArray();
            
            // roll the dice if there is a roll left, or else throw an exception
            if (RollsLeft > 0)
            {
                foreach (var die in enumerableDiceCup)
                {
                    die.Roll(_rng);
                }
                
                RollsLeft--;
            }
            else
            {
                throw new RoundOverException("You have run out of Rolls! Please choose a category");
            }
        }
    }

    public class RoundOverException : Exception
        {
            public RoundOverException(string message) : base(message)
            {
            }
        }
    }
