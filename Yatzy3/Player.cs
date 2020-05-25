using System;
using System.Linq;
using System.Text.RegularExpressions;
using YatzyGame.InputOutput;

namespace YatzyGame
{
    public class Player
    {
        private readonly IConsoleReader _consoleReader;

        public Player(IConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }

        public Response Respond()
        {
            var input = _consoleReader.GetInput();
            var match = Regex.Match(input, Constants.Regex);

            if (input.Split(Constants.Separator).All(s => int.TryParse(s, out _)))
            {
                var dieValuesToHold = input.Split(Constants.Separator);
                if (dieValuesToHold.Any(element => int.Parse(element) > 6))
                {
                    return new Response(ResponseType.InvalidResponse);
                }
                
                return new Response(ResponseType.HoldDice, input);
            }

            if (input.Equals(Constants.Reroll, StringComparison.OrdinalIgnoreCase))
            {
                return new Response(ResponseType.RerollDice);
            }

            if (match.Success && input.Length == 1)
            {
                return new Response(ResponseType.ScoreInCategory, input);
            }

            if (input.Equals(Constants.Quit, StringComparison.OrdinalIgnoreCase))
            {
                return new Response(ResponseType.QuitGame);
            }

            return new Response(ResponseType.InvalidResponse);
        }
    }
}