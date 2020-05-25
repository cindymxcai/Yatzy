using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyGame
{
    public class Round
    {
        public int RollsLeft { get; private set; } = 3;

        public void RollDice(IEnumerable<Die> diceCup, IRng rng)
        {
            var enumerableDice = diceCup.ToList();
            if (RollsLeft > 0)
            {
                foreach (var die in enumerableDice.Where(die => die.IsHeld == false))
                    die.Roll(rng);
                RollsLeft--;
            }
            else
            {
                throw new RoundOverException();
            }
            ResetDiceHeld(enumerableDice);
        }

        private static void ResetDiceHeld(IEnumerable<Die> diceCup)
        {
            foreach (var die in diceCup)
            {
                die.IsHeld = false;
            }
        }

        public static void HoldDice(Response response, List<Die> diceCup)
        {
            var dieValuesToHold = response.Input.Split(Constants.Separator);
            
            foreach (var holdValue in dieValuesToHold)
            {
                if (diceCup.Exists(die => die.Value == int.Parse(holdValue)))
                {
                    diceCup.First(die => !die.IsHeld && die.Value == int.Parse(holdValue)).IsHeld = true;
                }
                else
                {
                    response.ResponseType = ResponseType.InvalidResponse;
                }
            }
        }
    }

    public class RoundOverException : Exception
    {
    }
}