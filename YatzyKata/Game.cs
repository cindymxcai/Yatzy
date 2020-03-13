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
        public int RollsLeft = 3;


        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5)
        {
             DiceCup = new List<Die>{dice1, dice2, dice3, dice4, dice5};
        }
        
        public IEnumerable<int> GetValues()
        {
            return DiceCup.Select(die => die.Result);
        }

        public void DisplayRoll()
        {
            Console.WriteLine("Your current roll is:");
            foreach (var die in DiceCup)
            {
                Console.ForegroundColor 
                    = ConsoleColor.DarkMagenta;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("[" +die.Result + "]");
               Console.ResetColor();
            }
            Console.WriteLine("\n______________ You have {0} rolls left.", RollsLeft);
            DisplayCategories();
           if (RollsLeft > 0)
           {
               PromptAction();

           }
           
        }

        public void RollDice()
        {
            var zippedList = DiceCup.Zip(_currentlyHolding, (die, hold) => new
            {
                hold = hold,
                die = die
            });
            if (RollsLeft > 0)
            {
                foreach (var item in zippedList)
                {
                    if (item.hold == false)
                    {
                        item.die.RollDie();
                    }
                }

                RollsLeft--;
            }
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
            ScoreCalculator sc = new ScoreCalculator();
            var dice = DiceCup.Select(die => die.Result);
            IEnumerable<int> enumerable = dice as int[] ?? dice.ToArray();
            Console.WriteLine("Ones {0}", sc.Ones(enumerable));
            Console.WriteLine("Twos {0}", sc.Twos(enumerable));
            Console.WriteLine("Threes {0}", sc.Threes(enumerable));
            Console.WriteLine("Fours {0}", sc.Fours(enumerable));
            Console.WriteLine("Fives {0}", sc.Fives(enumerable));
            Console.WriteLine("Sixes {0}", sc.Sixes(enumerable));
            
        }
    }
}