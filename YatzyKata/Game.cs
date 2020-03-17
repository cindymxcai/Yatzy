using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace YatzyKata
{
    public class Game
    {
        private readonly IUserInput _userInput;
        public readonly List<Die> DiceCup;
        public static bool[]CurrentlyHolding ;
        public int RollsLeft = 3;
        ScoreCalculator sc = new ScoreCalculator();
        public Scorecard scorecard { get; set; }
        
        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5, IUserInput userInput)
        {
            _userInput = userInput;
            DiceCup = new List<Die> {dice1, dice2, dice3, dice4, dice5};
        }

        public IEnumerable<int> GetValues()
        {
            return DiceCup.Select(die => die.Result);
        }

        public void DisplayRoll()
        {
            Console.WriteLine("Your current roll is:");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("[A][B][C][D][E]");
            foreach (var die in DiceCup)
            {
                Console.Write("[" + die.Result + "]");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n___ You have {0} rolls left________", RollsLeft);
            Console.ResetColor();
            DisplayCategories();

            if (RollsLeft > 0)
            {
                PromptAction();
            }
        }

        public void RollDice()
        {
            var zippedList = DiceCup.Zip(CurrentlyHolding, (die, hold) => new
            {
                hold, die
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

        public void Hold(bool[] bools)
        {
            CurrentlyHolding = bools;
        }

        // TWOs & 10
        // TWOs & 10

        public void StoreScore(Category category, int score)
        {
            scorecard.AddScore(category, score);
        }
        public void PromptAction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________________________");
            Console.WriteLine("Enter: \n Category number to score \n Dice letter to hold\n or Enter to skip holding and scoring");
            // if the user input is a number, user has selected a category
            // numeric: Category, string: Dice hold, enter: , Reroll: _userInput.ProcessResponse();
            Category category;
            category = _userInput.GetCategoryResponse();
            var score = sc.GetScore(category,  DiceCup.Select(die => die.Result));
            scorecard.AddScore(category, score);
            Console.WriteLine("Enter R to reroll");
            Console.ResetColor();

            if (_userInput.GetRerollResponse())
            {
                RollDice();
            }

        }

        public  void DisplayCategories()
        {
            ScoreCalculator sc = new ScoreCalculator();
            var dice = DiceCup.Select(die => die.Result);
            var enumerable = dice.ToList();
            Console.WriteLine("1.Ones {0}", scorecard.Scores.FirstOrDefault(score => score.Category == Category.Ones)?.Score ?? sc.Ones(enumerable));
            Console.WriteLine("2.Twos {0}", sc.Twos(enumerable));
            Console.WriteLine("3.Threes {0}", sc.Threes(enumerable));
            Console.WriteLine("4.Fours {0}", sc.Fours(enumerable));
            Console.WriteLine("5.Fives {0}", sc.Fives(enumerable));
            Console.WriteLine("6.Sixes {0}", sc.Sixes(enumerable));
            Console.WriteLine("7.Pair {0}", sc.Pairs(enumerable));
            Console.WriteLine("8.Two pair {0}", sc.TwoPairs(enumerable));
            Console.WriteLine("9.3 of a Kind {0}", sc.ThreeOfAKind(enumerable));
            Console.WriteLine("10.4 of a Kind {0}", sc.FourOfAKind(enumerable));
            Console.WriteLine("11.Small Straight {0}", sc.SmallStraight(enumerable));
            Console.WriteLine("12.Large Straight {0}", sc.LargeStraight(enumerable));
            Console.WriteLine("13.Full House {0}", sc.FullHouse(enumerable));
            Console.WriteLine("14.Chance {0}", sc.getSumOfDice(enumerable));
            Console.WriteLine("15.Yatzy {0}", sc.Yatzy(enumerable));
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}