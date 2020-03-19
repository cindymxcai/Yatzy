using System;

namespace YatzyKata
{
    public class UserInput : IUserInput
    {
        private static readonly string Input = Console.ReadLine();
        public Category ChosenCategory { get; set; }

        
        public void GetResponseType()
        {
            if (int.TryParse(Input, out _))
            {
                GetCategoryResponse(Input);
            }
            else
            {
                GetHoldResponse(Input);
            }
        }
        

        public bool GetRerollResponse()
        {
            var input = Console.ReadLine();

            if (input == "R" || input == "r")
            {
                return true;
            }

            return false;
        }
        

        public void GetHoldResponse(String input)
        {

            string[] holdDice = input?.Split(',');

            if (holdDice != null)
                foreach (var letter in holdDice)
                {
                    if (letter == "a" || letter == "A")
                    {
                        Game.CurrentlyHolding[0] = true;
                    }

                    if (letter == "b" || letter == "B")
                    {
                        Game.CurrentlyHolding[1] = true;
                    }

                    if (letter == "c" || letter == "C")
                    {
                        Game.CurrentlyHolding[2] = true;
                    }

                    if (letter == "d" || letter == "D")
                    {
                        Game.CurrentlyHolding[3] = true;
                    }

                    if (letter == "e" || letter == "E")
                    {
                        Game.CurrentlyHolding[4] = true;
                    }
                }
        }
        
        public Category GetCategoryResponse(String input)
        {


            
            if (int.Parse(input) == 1)
            {
                ChosenCategory = Category.Ones;
            }
            if (int.Parse(input) == 2)
            {
                ChosenCategory = Category.Twos;
            }
            if (int.Parse(input) == 3)
            {
                ChosenCategory = Category.Threes;
            }
            if (int.Parse(input) == 4)
            {
                ChosenCategory = Category.Fours;
            }
            if (int.Parse(input) == 5)
            {
                ChosenCategory = Category.Fives;
            }
            if (int.Parse(input) == 6)
            {
                ChosenCategory = Category.Sixes;
            }
            if (int.Parse(input) == 7)
            {
                ChosenCategory = Category.Pairs;
            }
            if (int.Parse(input) == 8)
            {
                ChosenCategory = Category.TwoPairs;
            }
            if (int.Parse(input) == 9)
            {
                ChosenCategory = Category.ThreeOfAKind;
            }
            if (int.Parse(input) == 10)
            {
                ChosenCategory = Category.FourOfAKind;
            }
            if (int.Parse(input) == 11)
            {
                ChosenCategory = Category.SmallStraight;
            }
            if (int.Parse(input) == 12)
            {
                ChosenCategory = Category.LargeStraight;
            }
            if (int.Parse(input) == 13)
            {
                ChosenCategory = Category.FullHouse;
            }
            if (int.Parse(input) == 14)
            {
                ChosenCategory = Category.Chance;
            }
            if (int.Parse(input) == 15)
            {
                ChosenCategory = Category.Yatzy;
            }
            if (int.Parse(input) == 6)
            {
                ChosenCategory = Category.Sixes;
            }


            return ChosenCategory;
        }

    }
}