using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class Game : IGame
    {
        private readonly IUserInput _userInput;
        private readonly List<Die> _diceCup;
        private bool[]_currentlyHolding;
        public int RollsLeft = 3;
        private readonly ScoreCalculator _sc = new ScoreCalculator();
        public readonly ScoreCard ScoreCard = new ScoreCard(new List<CategoryScore>());
        
        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5, IUserInput userInput)
        {
            _userInput = userInput;
            _diceCup = new List<Die> {dice1, dice2, dice3, dice4, dice5};
        }

        public IEnumerable<int> GetValues()
        {
            return _diceCup.Select(die => die.Result);
        }

        public void DisplayRoll()
        {
            Console.WriteLine("Your current roll is:");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("[A][B][C][D][E]");
            foreach (var die in _diceCup)
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
                PlayRoundUntilNoRollsLeft();
            }
        }

        public void RollDice()
        {
            var zippedList = _diceCup.Zip(_currentlyHolding, (die, hold) => new
            {
                hold, die
            });
            
            if (RollsLeft > 0)
            {
                foreach (var item in zippedList)
                {
                    if (!item.hold)
                    {
                        item.die.RollDie();
                    }
                }

                RollsLeft--;
            }
            else if (RollsLeft == 0) 
            {
                ChooseCategoryIfNoRollsInRound();
            }
            DisplayRoll();
        }

        public void Hold(bool[] bools)
        {
            _currentlyHolding = bools;
        }

        public void StoreScore(Category category, int score)
        {
            ScoreCard.AddScore(category, score);
        }
        public void PlayRoundUntilNoRollsLeft()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________________________");
            Console.WriteLine("Enter: \n Category number to score \n Dice letter to hold\n or Enter to skip holding and scoring");
            var response = _userInput.GetResponse();
            //check the type of input given by the user in response
            //if responseType is reroll, roll dice, but do not score or hold dice
            //if responseType is category, score to scorecard, reset diceRolls to 3 and "start a new round"
            //if responseType is holdDice, hold the chosen dice and then reroll but do not score 

            if (response.ResponseType == ResponseType.PlayerChoseCategory)
            {
                var score = _sc.GetScore(response.ChosenCategory,  _diceCup.Select(die => die.Result)); 
                ScoreCard.AddScore(response.ChosenCategory, score);
                RollsLeft = 3; 
                RollDice();
            }

            if (response.ResponseType == ResponseType.PlayerChoseReroll)
            {
                RollDice();
            }

            if (response.ResponseType == ResponseType.PlayerChoseDiceToHold)
            {
                Hold(response.HeldDice);
                RollDice();
            }
            Console.ResetColor();
        }

        private void ChooseCategoryIfNoRollsInRound()
        {
            Console.WriteLine("No Rolls left in this round! Please choose a category to score.");
            var response = _userInput.GetResponse();
            if (response.ResponseType == ResponseType.PlayerChoseCategory)
            {
                var score = _sc.GetScore(response.ChosenCategory,  _diceCup.Select(die => die.Result)); 
                ScoreCard.AddScore(response.ChosenCategory, score);
                RollsLeft = 3; 
                RollDice();
            }
            else
            {
                Console.WriteLine("No more rolls in this round!");
            }

        }

        public  void DisplayCategories()
        {
            ScoreCalculator scoreCalculator = new ScoreCalculator();
            var dice = _diceCup.Select(die => die.Result);
            var enumerable = dice.ToList();
            Console.WriteLine("1.Ones {0}", ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Ones)?.Score ?? scoreCalculator.Ones(enumerable));
            Console.WriteLine("2.Twos {0}", ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Twos)?.Score ?? scoreCalculator.Twos(enumerable));
            Console.WriteLine("3.Threes {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Threes)?.Score ?? scoreCalculator.Threes(enumerable)));
            Console.WriteLine("4.Fours {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Fours)?.Score ?? scoreCalculator.Fours(enumerable)));
            Console.WriteLine("5.Fives {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Fives)?.Score ?? scoreCalculator.Fours(enumerable)));
            Console.WriteLine("6.Sixes {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Sixes)?.Score ?? scoreCalculator.Sixes(enumerable)));
            Console.WriteLine("7.Pair {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Pairs)?.Score ?? scoreCalculator.Pairs(enumerable)));
            Console.WriteLine("8.Two pair {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.TwoPairs)?.Score ?? scoreCalculator.TwoPairs(enumerable)));
            Console.WriteLine("9.3 of a Kind {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.ThreeOfAKind)?.Score ?? scoreCalculator.ThreeOfAKind(enumerable)));
            Console.WriteLine("10.4 of a Kind {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.FourOfAKind)?.Score ?? scoreCalculator.FourOfAKind(enumerable)));
            Console.WriteLine("11.Small Straight {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.SmallStraight)?.Score ?? scoreCalculator.SmallStraight(enumerable)));
            Console.WriteLine("12.Large Straight {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.LargeStraight)?.Score ?? scoreCalculator.LargeStraight(enumerable)));
            Console.WriteLine("13.Full House {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.FullHouse)?.Score ?? scoreCalculator.FullHouse(enumerable)));
            Console.WriteLine("14.Chance {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Chance)?.Score ?? scoreCalculator.getSumOfDice(enumerable)));
            Console.WriteLine("15.Yatzy {0}", (ScoreCard.Scores.FirstOrDefault(score => score.Category == Category.Yatzy)?.Score ?? scoreCalculator.Yatzy(enumerable)));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(("Your Total Score is: " + ScoreCard.Total()));
            Console.ResetColor();
        }
        
    }
}