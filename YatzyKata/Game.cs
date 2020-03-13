using System;
using System.Collections.Generic;
using System.Linq;
using DiceTests;

namespace YatzyKata
{
    public class Game
    {
        public readonly List<Die> DiceCup;
        private List<bool> _currentlyHolding;

        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5)
        {
             DiceCup = new List<Die>{dice1, dice2, dice3, dice4, dice5};
        }
        
        public List<int> GetValues()
        {
            return (List<int>) DiceCup.Select(die => die.Result);
        }

        public void DisplayRoll()
        {
            Console.WriteLine("Your current roll is:");
            foreach (var die in DiceCup)
            {
                Console.Write("[" +die.Result + "]");
            }
            Console.WriteLine("\n______________");
           // DisplayCategories();
            PromptAction();
        }

        public void RollDice()
        {
            int RollsLeft = 3;
            var zippedList = DiceCup.Zip(_currentlyHolding, (die, hold) => new
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
            DisplayRoll();
        }

        public void Hold(List<bool> bools)
        {
            _currentlyHolding = bools;
        }

        public void PromptAction()
        {
            Console.WriteLine("Enter dice number to hold, or R to reroll");
            var input = Console.ReadLine();

            if (input == "R" || input == "r")
            {
                RollDice();
                DisplayRoll();
            }
            else
            {
                var i = int.Parse(input);
                if (i >= 1 && i <= 6)
                {
                    if (i == 1)
                    {
                        _currentlyHolding = new List<bool> {true};
                        Hold(_currentlyHolding);
                        RollDice();
                    }

                    if (i == 2)
                    {
                        _currentlyHolding = new List<bool>{false, true};
                        Hold(_currentlyHolding);
                        RollDice();
                    }

                }
            }
        }

        public void DisplayCategories()
        {
            var values = GetValues();
            ScoreCalculator sc = new ScoreCalculator();
            Console.WriteLine("Ones {0}", sc.Ones(values));
        }
    }
}