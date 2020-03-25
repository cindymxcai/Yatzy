using System;
using System.Linq;

namespace YatzyKata
{
    public enum ResponseType
    {
        PlayerChoseCategory,
        PlayerChoseDiceToHold,
        PlayerChoseReroll,
        PlayerChoseQuit
    }

    public class Response
    {
        public readonly ResponseType ResponseType;
        public readonly bool[] HeldDice;
        public readonly Category ChosenCategory;
        public readonly bool IsReroll;
        public readonly string Quit;

        public Response(Category category)
        {
            ResponseType = ResponseType.PlayerChoseCategory;
            ChosenCategory = category;
        }

        public Response(bool[] heldDice)
        {
            ResponseType = ResponseType.PlayerChoseDiceToHold;
            HeldDice = heldDice;
        }

        public Response(ResponseType chosenResponseType)
        {
            ResponseType = chosenResponseType;
        }

        private bool Equals(Response other)
        {
            return ResponseType == other.ResponseType ||
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
            return HashCode.Combine((int) ResponseType,  HeldDice, (int) ChosenCategory);
        }
    }

    public class UserInput : IUserInput
    {
        public readonly IConsoleReader ConsoleReader;


        public UserInput(IConsoleReader consoleReader)
        {
            ConsoleReader = consoleReader;
        }


        public Response GetResponse()
        {
            var input = ConsoleReader.GetInput();
            if (IsReroll(input))
            {
                return new Response(ResponseType.PlayerChoseReroll);
            }

            if (IsQuit(input))
            {
                return new Response(ResponseType.PlayerChoseQuit);
            }
            
            return int.TryParse(input, out _) ? GetCategoryResponse(input) : GetHoldResponse(input);
        }


        public bool IsReroll(string input)
        {
            return input == "R" || input == "r";
        }

        public bool IsQuit(string input)
        {
            return input == "Q" || input == "q";
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