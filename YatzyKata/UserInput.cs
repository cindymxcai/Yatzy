using System;
using System.Linq;

namespace YatzyKata
{
    public enum ResponseType
    {
        PlayerChoseCategory,
        PlayerChoseDiceToHold
    }

    public class Response
    {
        private readonly ResponseType _responseType;
        public readonly bool[] HeldDice;
        public readonly Category ChosenCategory;

        public Response(Category category)
        {
            _responseType = ResponseType.PlayerChoseCategory;
            ChosenCategory = category;
        }

        public Response(bool[] heldDice)
        {
            _responseType = ResponseType.PlayerChoseDiceToHold;
            HeldDice = heldDice;
        }

        private bool Equals(Response other)
        {
            return _responseType == other._responseType ||
                   ChosenCategory == other.ChosenCategory || 
                   HeldDice.SequenceEqual( other.HeldDice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Response) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) _responseType,  HeldDice, (int) ChosenCategory);
        }
    }

    public enum Dice
    {
        None,
        DiceA,
        DiceB,
        DiceC,
        DiceD,
        DiceE
    }

    public class UserInput : IUserInput
    {
        private readonly IConsoleReader _consoleReader;

        public UserInput(IConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }


        public Response GetResponse()
        {
            var input = _consoleReader.GetInput();

            return int.TryParse(input, out _) ? GetCategoryResponse(input) : GetHoldResponse(input);
        }


        public bool GetRerollResponse()
        {
            var input = _consoleReader.GetInput();

            return input == "R" || input == "r";
        }


        public Response GetHoldResponse(string input)
        {
            string[] holdDice = input?.Split(',');

            if (holdDice == null) return new Response(new []{false, false, false, false, false});

            var response = new Response(new [] {false, false, false, false, false});
            
            foreach (var letter in holdDice)
            {
                if (letter.Equals("a", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.HeldDice[0] = true;
                }

                if (letter.Equals("b", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.HeldDice[1] = true;
                }

                if (letter.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.HeldDice[2] = true;
                }

                if (letter.Equals("d", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.HeldDice[3] = true;
                }

                if (letter.Equals("e", StringComparison.InvariantCultureIgnoreCase))
                {
                    response.HeldDice[4] = true;
                }
            }

            return response;
        }

        public Response GetCategoryResponse(String input)
        {
            return int.Parse(input) switch
            {
                1 => new Response(Category.Ones),
                2 => new Response(Category.Twos),
                3 => new Response(Category.Threes),
                4 => new Response(Category.Fours),
                5 => new Response(Category.Fives),
                6 => new Response(Category.Sixes),
                7 => new Response(Category.Pairs),
                8 => new Response(Category.TwoPairs),
                9 => new Response(Category.ThreeOfAKind),
                10 => new Response(Category.FourOfAKind),
                11 => new Response(Category.SmallStraight),
                12 => new Response(Category.LargeStraight),
                13 => new Response(Category.FullHouse),
                14 => new Response(Category.Chance),
                15 => new Response(Category.Yatzy),
                _ => new Response(Category.None)
            };
        }
    }
}