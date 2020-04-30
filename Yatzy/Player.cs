using System;
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

        public Response Response()
        {
            var input = _consoleReader.GetInput();

            if (int.TryParse(input, out _) || int.TryParse(input.Split(',')[0], out _))
            {
                var splitInput = input.Split(',');
                if (splitInput.Any(element => int.Parse(element) > 6))
                {
                    throw new InvalidResponseException("Please enter valid dice to hold");
                }
                return Yatzy.Response.HoldDice;
            }
            
            if(input == "r" || input == "R")
            {
                return Yatzy.Response.RerollDice;
            }
            
            const string regex = "[a-oA-O]";
            var match = Regex.Match(input, regex);
            if (match.Success && input.Count() == 1)
            {
                return Yatzy.Response.ScoreInCategory;
            }
            
            if (input == "q" || input == "Q")
            {
                return Yatzy.Response.QuitGame;
            }
            throw new InvalidResponseException("Please enter a valid input!");
        }
    }

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message): base(message)
        {
        }
    }
}