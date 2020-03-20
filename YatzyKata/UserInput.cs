using System;

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
        private readonly Dice _heldDice;
        public readonly Category ChosenCategory;

        public Response(Category category)
        {
            _responseType = ResponseType.PlayerChoseCategory;
            ChosenCategory = category;
        }

        public Response(Dice heldDice)
        {
            _responseType = ResponseType.PlayerChoseDiceToHold;
            _heldDice = heldDice;
        }

        private bool Equals(Response other)
        {
            return _responseType == other._responseType && _heldDice == other._heldDice &&
                   ChosenCategory == other.ChosenCategory;
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
            return HashCode.Combine((int) _responseType, (int) _heldDice, (int) ChosenCategory);
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
            var input = Console.ReadLine();

            return input == "R" || input == "r";
        }


        public Response GetHoldResponse(String input)
        {
            string[] holdDice = input?.Split(',');

            if (holdDice == null) return new Response(Dice.None);
            foreach (var letter in holdDice)
            {
                if (letter.Equals("a", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Response(Dice.DiceA);
                }

                if (letter.Equals("b", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Response(Dice.DiceB);
                }

                if (letter.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Response(Dice.DiceC);
                }

                if (letter.Equals("d", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Response(Dice.DiceD);
                }

                if (letter.Equals("e", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new Response(Dice.DiceE);
                }
            }

            return new Response(Dice.None);
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