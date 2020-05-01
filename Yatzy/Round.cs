using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Round
    {
        private int MaxRolls { get; } = 3;
        private int RollsTaken { get; set; }
        private readonly IRng _rng = new Rng();

        public void RollDice(IEnumerable<Die> diceCup)
        {
            var enumerableDiceCup = diceCup as Die[] ?? diceCup.ToArray();
            if (RollsTaken < MaxRolls)
            {
                foreach (var die in enumerableDiceCup)
                {
                    die.Roll(_rng);
                }
            }
            else
            {
                throw new RoundOverException("You have run out of Rolls! Please choose a category");
            }
            Display.DisplayDice(enumerableDiceCup);
            RollsTaken++;
        }
    }

    public class RoundOverException : Exception
        {
            public RoundOverException(string message) : base(message)
            {
            }
        }
    }
