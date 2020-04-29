using System;
using System.Collections.Generic;
using Yatzy;

namespace YatzyTest
{
    public class Round
    {
        private int  MaxRolls { get; } = 3;
        private int RollsTaken { get; set; }
        private readonly IRng _rng = new Rng();
        public void RollDice(IEnumerable<Die> diceCup)
        {
            if (RollsTaken < MaxRolls)
            {
                foreach (var die in diceCup)
                {
                    die.Roll(_rng);
                }
            }
            else
            {
                throw new RoundOverException("You have run out of Rolls! Please choose a category");
            }

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