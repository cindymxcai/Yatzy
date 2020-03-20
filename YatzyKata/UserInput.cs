using System;
using System.Collections.Generic;

namespace YatzyKata
{
    public enum ResponseType
    {
        PlayerChoseCategory,
        PlayerChoseDiceToHold
    }
    public class Response
    {
        public ResponseType ResponseType;
        public  HeldDice HeldDice;
        public Category ChosenCategory;
    }

    public enum HeldDice
    {
        None,
        diceA,
        diceB,
        diceC, 
        diceD,
        diceE
    }

    public class UserInput : IUserInput
    {
        public Response GetResponse()
        {
            var Input = Console.ReadLine();

            if (int.TryParse(Input, out _))
            {
                return GetCategoryResponse(Input);
            }
            else
            {
                return GetHoldResponse(Input);
            }
        }
        

        public bool GetRerollResponse()
        {
            var input = Console.ReadLine();

            if (input == "R" || input == "r") // ignore case compare
            {
                return true;
            }

            return false;
        }
        

        public Response GetHoldResponse(String input)
        {

            string[] holdDice = input?.Split(',');

            if (holdDice != null)
                foreach (var letter in holdDice)
                {
                    if (letter == "a" || letter == "A")
                    {
                        return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.diceA};
                    }

                    if (letter == "b" || letter == "B")
                    {
                        return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.diceB};
                    }

                    if (letter == "c" || letter == "C")
                    {
                        return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.diceC};
                    }

                    if (letter == "d" || letter == "D")
                    {
                        return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.diceD};
                    }

                    if (letter == "e" || letter == "E")
                    {
                        return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.diceE};
                    }
                }
            return new Response {ResponseType = ResponseType.PlayerChoseDiceToHold, HeldDice = HeldDice.None};

        }
        
        public Response GetCategoryResponse(String input)
        {

            if (int.Parse(input) == 1)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Ones};
            }

            if (int.Parse(input) == 2)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Twos};
            }
            if (int.Parse(input) == 3)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Threes};
            }
            if (int.Parse(input) == 4)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Fours};
            }
            if (int.Parse(input) == 5)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Fives};
            }
            if (int.Parse(input) == 6)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Sixes};
            }
            if (int.Parse(input) == 7)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Pairs};
            }
            if (int.Parse(input) == 8)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.TwoPairs};
            }
            if (int.Parse(input) == 9)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.ThreeOfAKind};
            }
            if (int.Parse(input) == 10)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.FourOfAKind};
            }
            if (int.Parse(input) == 11)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.SmallStraight};
            }
            if (int.Parse(input) == 12)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.LargeStraight};
            }
            if (int.Parse(input) == 13)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.FullHouse};
            }
            if (int.Parse(input) == 14)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Chance};
            }
            if (int.Parse(input) == 15)
            {
                return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.Yatzy};
            }
           


            return new Response {ResponseType = ResponseType.PlayerChoseCategory, ChosenCategory = Category.None};

        }

    }
}