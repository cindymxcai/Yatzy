using System.Linq;
using System.Text.RegularExpressions;

namespace Yatzy
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

            if (int.TryParse(input, out _) || int.TryParse(input.Split(',')[0], out _))
            {
                var splitInput = input.Split(',');
                if (splitInput.Any(element => int.Parse(element) > 6))
                {
                    throw new InvalidResponseException("Please enter valid dice to hold");
                }
                return new Response(ResponseType.HoldDice, input);
            }
            
            if(input == "r" || input == "R")
            {
                return  new Response(ResponseType.RerollDice);
            }
            
            const string regex = "[a-oA-O]";
            var match = Regex.Match(input, regex);
            if (match.Success && input.Count() == 1)
            {
                return new Response(ResponseType.ScoreInCategory, input);
            }
            
            if (input == "q" || input == "Q")
            {
                return new Response(ResponseType.QuitGame);
            }
            
            return new Response(ResponseType.InvalidResponse);
        }
    }
}