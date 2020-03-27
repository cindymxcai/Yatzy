using System;
using System.Collections.Generic;
using System.Linq;

namespace YatzyKata
{
    public class Game : IGame
    {
        private readonly IUserInput _userInput;
        private readonly List<Die> _diceCup;
        private bool[] _currentlyHolding;
        public int RollsLeft = 3;
        private readonly ScoreCalculator _sc = new ScoreCalculator();
        public readonly ScoreCard ScoreCard = new ScoreCard(new List<CategoryScore>());
        public bool PlayingGame = true;
        private bool _playingRound = true;

        public Game(Die dice1, Die dice2, Die dice3, Die dice4, Die dice5, IUserInput userInput, bool[] currentlyHolding)
        {
            _userInput = userInput;
            _diceCup = new List<Die>
            {
                dice1,
                dice2,
                dice3,
                dice4,
                dice5
            };
            _currentlyHolding = currentlyHolding;
        }

        public IEnumerable<int> GetValues()
        {
            return _diceCup.Select(die => die.Result);
        }

        void IGame.PlayRoundUntilNoRollsLeft()
        {
            PlayRound();
        }

        public void Play()
        {
            while (PlayingGame)
            {
                _playingRound = true;
                RollsLeft = 3;
                while (_playingRound)
                {
                    RollDice();
                    DisplayRoll();
                    if (RollsLeft > 0)
                    {
                        PlayRound();
                    }
                    else
                    {
                        _playingRound = false;
                        ChooseCategoryIfNoRollsInRound();
                    }
                    
                    if (ScoreCard.Scores.Count == Enum.GetNames(typeof(Category)).Length-1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Game over! Your Total was {0}", ScoreCard.Total);
                        _playingRound = false;
                        PlayingGame = false;
                    }
                }
            }
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
        }

        public void RollDice()
        {
            var zippedList = _diceCup.Zip(_currentlyHolding, (die, hold) => new {hold, die});
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
        }

        public void Hold(bool[] bools)
        {
            _currentlyHolding = bools;
        }

        public void StoreScore(Category category, int score)
        {
            ScoreCard.AddScore(category, score);
        }

        public void PlayRound()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________________________");
            Console.WriteLine(
                "Enter: \n Category number to score \n Dice letter to hold\n or Enter to skip holding and scoring");
            var response = _userInput.GetResponse();
            //check the type of input given by the user in response
            //if responseType is reroll, roll dice, but do not score or hold dice
            //if responseType is category, score to scorecard, reset diceRolls to 3 and "start a new round"
            //if responseType is holdDice, hold the chosen dice and then reroll but do not score 
            if (response.ResponseType == ResponseType.PlayerChoseCategory)
            {
                if (ScoreCard.Scores.Any(categoryScore => categoryScore.Category == response.ChosenCategory))
                {
                    Console.WriteLine("Category has already been scored! Try again");
                    PlayRound();
                }
                else
                {
                    var score = _sc.GetScore(response.ChosenCategory, _diceCup.Select(die => die.Result));
                    ScoreCard.AddScore(response.ChosenCategory, score);
                    RollsLeft = 3;
                    _playingRound = false;
                }
            }

            if (response.ResponseType == ResponseType.PlayerChoseReroll)
            {
                _playingRound = true;
            }
            else if (response.ResponseType == ResponseType.PlayerChoseDiceToHold)
            {
                Hold(response.HeldDice);
                _playingRound = true;
            }
            else if (response.ResponseType == ResponseType.PlayerChoseQuit)
            {
                PlayingGame = false;
                _playingRound = false;
            }

            Console.ResetColor();
        }

        private void ChooseCategoryIfNoRollsInRound()
        {
            Console.WriteLine("No Rolls left in this round! Please choose a category to score.");
            var response = _userInput.GetResponse();
            if (response.ResponseType == ResponseType.PlayerChoseCategory)
            {
                var score = _sc.GetScore(response.ChosenCategory, _diceCup.Select(die => die.Result));
                ScoreCard.AddScore(response.ChosenCategory, score);
                RollsLeft = 3;
            }
        }

        private int GetCategoryScoreOrCalculate(Category category, int number, IEnumerable<int> enumerable )
        {
           return ScoreCard.Scores.FirstOrDefault(score => score.Category == category)?.Score ?? _sc.NumberScores(enumerable, number);
        }
        
        public void DisplayCategories()
        {
            foreach (var score in ScoreCard.Scores)
            {
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    if (score.Category == category)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                }
            }

            var scoreCalculator = new ScoreCalculator();
            var dice = _diceCup.Select(die => die.Result);
            var enumerable = dice.ToList();
            
            Console.WriteLine("1.Ones {0}", GetCategoryScoreOrCalculate(Category.Ones, 1, enumerable));
            Console.WriteLine("2.Twos {0}",GetCategoryScoreOrCalculate(Category.Twos, 2, enumerable));
            Console.WriteLine("3.Threes {0}",GetCategoryScoreOrCalculate(Category.Threes, 3, enumerable));
            Console.WriteLine("4.Fours {0}", GetCategoryScoreOrCalculate(Category.Fours, 4, enumerable)); 
            Console.WriteLine("5.Fives {0}", GetCategoryScoreOrCalculate(Category.Fives, 5, enumerable));
            Console.WriteLine("6.Sixes {0}", GetCategoryScoreOrCalculate(Category.Sixes, 6, enumerable));
            Console.WriteLine("7.Pair {0}", ScoreCard.GetScore(Category.Pairs) ?? scoreCalculator.Pairs(enumerable));
            Console.WriteLine("8.Two pair {0}", ScoreCard.GetScore(Category.TwoPairs) ?? scoreCalculator.TwoPairs(enumerable));
            Console.WriteLine("9.Three of a Kind {0}", ScoreCard.GetScore(Category.ThreeOfAKind) ?? scoreCalculator.ThreeOfAKind(enumerable));
            Console.WriteLine("10.Four of a Kind {0}", ScoreCard.GetScore(Category.FourOfAKind) ?? scoreCalculator.FourOfAKind(enumerable));
            Console.WriteLine("11.Small Straight {0}", ScoreCard.GetScore(Category.SmallStraight) ?? scoreCalculator.SmallStraight(enumerable));
            Console.WriteLine("12.Large Straight {0}", ScoreCard.GetScore(Category.LargeStraight) ?? scoreCalculator.LargeStraight(enumerable));
            Console.WriteLine("13.Full House {0}", ScoreCard.GetScore(Category.FullHouse) ?? scoreCalculator.FullHouse(enumerable));
            Console.WriteLine("14.Chance {0}", ScoreCard.GetScore(Category.Chance) ?? scoreCalculator.GetSumOfDice(enumerable));
            Console.WriteLine("15.Yatzy {0}", ScoreCard.GetScore(Category.Yatzy) ?? scoreCalculator.Yatzy(enumerable));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(("Your Total Score is: " + ScoreCard.Total));
            Console.ResetColor();
            Console.WriteLine("Categories already scored: ");
            foreach (var score in ScoreCard.Scores)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(score.Category + ": " + score.Score);
                Console.ResetColor();
            }
        }
        
    }
}